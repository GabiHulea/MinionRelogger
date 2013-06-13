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
using System.Linq;
using System.Threading;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Interfaces.RelogWorkers;

namespace MinionReloggerLib.Threads.Implementation
{
    internal class InstanceThread : IRelogThread
    {
        private readonly Thread _instanceThread;
        private int _delay;
        private bool _isRunning;
        private bool _keepAlive;
        private bool _needDelay;

        public InstanceThread()
        {
            _instanceThread = new Thread(DoWork)
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
            return _instanceThread;
        }

        public string GetName()
        {
            return "InstanceThread";
        }

        public bool IsRunning()
        {
            return _instanceThread.IsAlive && _isRunning;
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
                _instanceThread.Start();
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

                    foreach (Account account in Config.Singleton.AccountSettings.ToArray())
                    {
                        var results = new List<EComponentResult>();
                        foreach (
                            ComponentClass component in
                                ComponentManager.Singleton.GetComponents().ToArray().Where(c => c.IsEnabled))
                        {
                            var result = EComponentResult.Default;
                            component.Component.DoWork(account, ref result);
                            results.Add(result);
                        }
                        if (results.Any(r => r == EComponentResult.KillForced))
                        {
                            new KillWorker().DoWork(account).Update(account);
                        }
                        else if (results.Any(r => r == EComponentResult.HaltForced))
                        {
                            account.SetLastStopTime(DateTime.Now);
                        }
                        else if (results.Any(r => r == EComponentResult.StartForced))
                        {
                            new StartWorker().DoWork(account);
                        }
                        else if (results.Any(r => r == EComponentResult.ContinueForced))
                        {
                            continue;
                        }
                        else if (results.Any(r => r == EComponentResult.Kill))
                        {
                            new KillWorker().DoWork(account).Update(account);
                        }
                        else if (results.Any(r => r == EComponentResult.Halt))
                        {
                            continue;
                        }
                        else if (results.Any(r => r == EComponentResult.Start))
                        {
                            try
                            {
                                new StartWorker().DoWork(account).Update(account);
                            }
                            finally
                            {
                                GC.Collect();
                            }
                        }
                        else if (results.Any(r => r == EComponentResult.Continue))
                        {
                            continue;
                        }
                        else if (results.Any(r => r == EComponentResult.Ignore))
                        {
                            continue;
                        }
                        else if (results.Any(r => r == EComponentResult.Default))
                        {
                            continue;
                        }
                    }
                    Thread.Sleep(Config.Singleton.GeneralSettings.PollingDelay*1000);
                }
                Thread.Sleep(10000);
            }
        }
    }
}