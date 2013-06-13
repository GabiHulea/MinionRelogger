/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Alpha -- https://github.com/Vipeax/MinionRelogger   *
*  Copyright (C) 2013, Robert van den Boorn                                  *
*                                                                            *
*  This program is free software: you can redistribute it and/or modify      *
*   it under the terms of the GNU General Public License as published by     *
*   the Free Software Foundation, either version 3 of the License, or        *
*   (at your option) any later version.                                      *
*                                                                            *
*   This program is distributed in the hope that it will be useful,          *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*                                                                            *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Threads.Implementation
{
    internal class GW2ManagerThread : IRelogThread
    {
        private static readonly Dictionary<Process, WatchObject> FrozenGW2Windows =
            new Dictionary<Process, WatchObject>();

        private static int _checkAll;

        private readonly Thread _gw2ManagerThread;
        private int _delay;
        private bool _isRunning;
        private bool _keepAlive;
        private bool _needDelay;

        public GW2ManagerThread()
        {
            _gw2ManagerThread = new Thread(DoWork)
                {
                    IsBackground = true,
                };
            _delay = 0;
            _needDelay = false;
            _isRunning = false;
            _keepAlive = false;
        }

        public Thread GetThread()
        {
            return _gw2ManagerThread;
        }

        public string GetName()
        {
            return "GW2ManagerThread";
        }

        public bool IsRunning()
        {
            return _gw2ManagerThread.IsAlive && _isRunning;
        }

        public void Delay(int delay)
        {
            _delay = delay;
            _needDelay = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Start()
        {
            if (!_keepAlive)
            {
                _keepAlive = true;
                _gw2ManagerThread.Start();
            }
            _isRunning = true;
        }

        public void DoWork()
        {
            while (_keepAlive)
            {
                while (_isRunning)
                {
                    if (_needDelay)
                    {
                        Thread.Sleep(_delay);
                    }
                    User32.EnumWindows(EnumTheWindows, IntPtr.Zero);
                    Thread.Sleep(Config.Singleton.GeneralSettings.PollingDelay*1000);
                }
                Thread.Sleep(10000);
            }
        }

        protected static bool EnumTheWindows(IntPtr hWnd, IntPtr lParam)
        {
            int size = User32.GetWindowTextLength(hWnd);
            if (size++ > 0 && User32.IsWindowVisible(hWnd))
            {
                var sb = new StringBuilder(size);
                User32.GetWindowText(hWnd, sb, size);
                if (sb.ToString().ToLower() == "gw2.exe" ||
                    sb.ToString().ToLower() == "guild wars 2 game client")
                {
                    Process firstOrDefault = Process.GetProcesses().FirstOrDefault(p => p.MainWindowHandle == hWnd);
                    if (firstOrDefault != null)
                        firstOrDefault.Kill();
                }
            }
            if (_checkAll > 6 || Config.Singleton.GeneralSettings.PollingDelay >= 20000)
            {
                Process[] gw2Processes = UpdateListWithRemainingGW2Processes();
                foreach (Process gw2Process in gw2Processes)
                {
                    UpdateProcessIdForMatchingScheduler(gw2Process);
                    if (!gw2Process.Responding)
                    {
                        if (FrozenGW2Windows.All(p => p.Key.Id != gw2Process.Id))
                        {
                            AddUnresponsiveProcessToTheList(gw2Process);
                        }
                        else
                        {
                            GetRidOfProcessesThatHaveBeenFrozenForLong(gw2Process);
                        }
                    }
                    else
                    {
                        RemoveRespondingWindowsFromTheList(gw2Process);
                        MinimizeGW2Windows(gw2Process);
                    }
                }
                _checkAll = -1;
            }
            _checkAll++;
            return true;
        }

        private static Process[] UpdateListWithRemainingGW2Processes()
        {
            Process[] gw2Processes = Process.GetProcessesByName("GW2");
            for (int i = 0; i < FrozenGW2Windows.Count; i++)
            {
                if (FrozenGW2Windows.ElementAt(i).Key.HasExited)
                {
                    FrozenGW2Windows.Remove(FrozenGW2Windows.ElementAt(i).Key);
                    i--;
                }
            }
            return gw2Processes;
        }

        private static void UpdateProcessIdForMatchingScheduler(Process gw2Process)
        {
            if (Config.Singleton.AccountSettings.All(a => a.PID != gw2Process.Id))
            {
                string name = GW2MinionLauncher.GetAccountName((uint) gw2Process.Id);
                Account wanted =
                    Config.Singleton.AccountSettings.FirstOrDefault(a => a.LoginName == name);
                if (wanted != null)
                {
                    wanted.SetPID((uint) gw2Process.Id);
                    wanted.SetShouldBeRunning(true);
                }
            }
        }

        private static void AddUnresponsiveProcessToTheList(Process gw2Process)
        {
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(a => a.PID == gw2Process.Id);
            if (wanted != null)
            {
                FrozenGW2Windows.Add(gw2Process, new WatchObject(wanted, DateTime.Now, gw2Process));
                Logger.LoggingObject.Log(ELogType.Critical,
                                         LanguageManager.Singleton.GetTranslation(
                                             ETranslations.GW2ManagerThreadStoppedResponding),
                                         wanted.LoginName);
            }
            else
            {
                FrozenGW2Windows.Add(gw2Process, new WatchObject(new Account(), DateTime.Now, gw2Process));
            }
        }


        private static void GetRidOfProcessesThatHaveBeenFrozenForLong(Process gw2Process)
        {
            KeyValuePair<Process, WatchObject> wanted =
                FrozenGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
            if (wanted.Key != null && (DateTime.Now - wanted.Value.Time).TotalSeconds > 90)
            {
                if (wanted.Value.Account != null && wanted.Value.Check())
                {
                    wanted.Value.DoWork();
                }
            }
        }

        private static void RemoveRespondingWindowsFromTheList(Process gw2Process)
        {
            KeyValuePair<Process, WatchObject> wanted =
                FrozenGW2Windows.FirstOrDefault(p => p.Key.Id == gw2Process.Id);
            if (wanted.Key != null)
            {
                if (wanted.Value.Account != null)
                    Logger.LoggingObject.Log(ELogType.Critical,
                                             LanguageManager.Singleton.GetTranslation(
                                                 ETranslations.GW2ManagerThreadStartedRespondingAgain),
                                             wanted.Value.Account.LoginName);
                FrozenGW2Windows.Remove(wanted.Key);
            }
        }

        private static void MinimizeGW2Windows(Process gw2Process)
        {
            if (Config.Singleton.GeneralSettings.MinimizeWindows &&
                Config.Singleton.AccountSettings.Any(a => a.PID == gw2Process.Id))
            {
                try
                {
                    IntPtr hwnd = Process.GetProcessById(gw2Process.Id).MainWindowHandle;
                    if (!hwnd.Equals(IntPtr.Zero))
                    {
                        User32.ShowWindowAsync(hwnd, User32.SW_SHOWMINIMIZED);
                    }
                }
                catch (Exception ex)
                {
                    Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                }
            }
        }
    }
}