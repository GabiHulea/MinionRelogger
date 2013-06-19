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
using System.IO;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Interfaces.RelogWorkers
{
    public class StartWorker : IRelogWorker
    {
        private bool _attached;
        private Process[] _gw2Processes;
        private uint _newPID;

        public bool Check(Account account)
        {
            return CheckIfProcessAlreadyExists(_gw2Processes, account, _attached, ref _newPID);
        }

        public IRelogWorker DoWork(Account account)
        {
            _attached = false;
            _newPID = uint.MaxValue;
            _gw2Processes = Process.GetProcessesByName("gw2");
            Logger.LoggingObject.Log(ELogType.Debug,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.StartWorkerScanningForExisting));
            _attached = Check(account);
            _newPID = CreateNewProcess(_attached, account, ref _newPID);
            Update(account);
            return this;
        }

        public void Update(Account account)
        {
            account.SetRestartDelayActive(false);
            account.SetPID(_newPID);
            account.SetLastStartTime(DateTime.Now);
        }

        public bool PostWork(Account account)
        {
            return _newPID < uint.MaxValue;
        }

        private uint CreateNewProcess(bool attached, Account account, ref uint newPID)
        {
            if (!attached)
            {
                try
                {
                    try
                    {
                        if (account.BotPath != AppDomain.CurrentDomain.BaseDirectory &&
                            Directory.Exists(account.BotPath) &&
                            File.Exists(account.BotPath + "GW2MinionLauncherDLL.dll"))
                            Kernel32.SetDllDirectory(account.BotPath);
                        Logger.LoggingObject.Log(ELogType.Verbose,
                                                 LanguageManager.Singleton.GetTranslation(
                                                     ETranslations.StartWorkerLaunchingInstance),
                                                 account.LoginName, account.BotPath + "GW2MinionLauncherDLL.dll");
                        string directory = Config.Singleton.GeneralSettings.GW2Path.Replace("GW2.exe", "");
                        if (Directory.Exists(directory))
                        {
                            if (File.Exists(directory + "ArenaNet.log"))
                            {
                                File.Delete(directory + "ArenaNet.log");
                            }
                            if (File.Exists(directory + "Crash.dmp"))
                            {
                                File.Delete(directory + "Crash.dmp");
                            }
                        }
                        if (Directory.Exists(directory))
                        {
                            if (File.Exists(directory + "ArenaNet.log"))
                            {
                                File.Delete(directory + "ArenaNet.log");
                            }
                            if (File.Exists(directory + "Crash.dmp"))
                            {
                                File.Delete(directory + "Crash.dmp");
                            }
                        }
                        string mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        if (Directory.Exists(mydocuments))
                        {
                            if (Directory.Exists(mydocuments + "\\Guild Wars 2"))
                            {
                                if (File.Exists(mydocuments + "\\Guild Wars 2\\" + "ArenaNet.log"))
                                {
                                    File.Delete(mydocuments + "\\Guild Wars 2\\" + "ArenaNet.log");
                                }
                                const string filesToDelete = @"*Corrupt*.dat";
                                string[] fileList = Directory.GetFiles(mydocuments + "\\Guild Wars 2", filesToDelete);
                                foreach (string file in fileList)
                                {
                                    File.Delete(file);
                                }
                            }
                        }
                        newPID = GW2MinionLauncher.LaunchAccount(Config.Singleton.GeneralSettings.GW2Path,
                                                                 account.LoginName, account.Password, account.NoSound);
                    }
                    catch (Exception ex)
                    {
                        Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                    }
                    account.SetLastStartTime(DateTime.Now);
                    account.SetShouldBeRunning(true);
                }
                catch (DllNotFoundException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
                catch (BadImageFormatException ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
            }
            return newPID;
        }

        private bool CheckIfProcessAlreadyExists(IEnumerable<Process> gw2Processes, Account account, bool attached,
                                                 ref uint newPID)
        {
            foreach (Process p in gw2Processes)
            {
                if (GW2MinionLauncher.GetAccountName((uint) p.Id) == account.LoginName)
                {
                    Logger.LoggingObject.Log(ELogType.Verbose,
                                             LanguageManager.Singleton.GetTranslation(
                                                 ETranslations.StartWorkerFoundWantedProcess),
                                             account.LoginName);
                    try
                    {
                        Logger.LoggingObject.Log(ELogType.Verbose,
                                                 LanguageManager.Singleton.GetTranslation(
                                                     ETranslations.StartWorkerAttachingTo),
                                                 account.LoginName, account.BotPath + "\\GW2MinionLauncherDLL.dll");
                        if (account.BotPath != AppDomain.CurrentDomain.BaseDirectory &&
                            Directory.Exists(account.BotPath) &&
                            File.Exists(account + "\\GW2MinionLauncherDLL.dll"))
                            Kernel32.SetDllDirectory(account.BotPath);
                        attached = GW2MinionLauncher.AttachToPid((uint) p.Id);
                    }
                    catch (Exception ex)
                    {
                        Logger.LoggingObject.Log(ELogType.Critical, ex.Message);
                    }
                    newPID = (uint) p.Id;

                    account.SetLastStartTime(DateTime.Now);
                    account.SetShouldBeRunning(true);
                }
            }
            return attached;
        }
    }
}