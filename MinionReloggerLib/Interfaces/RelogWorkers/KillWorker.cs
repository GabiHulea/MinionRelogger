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
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Imports;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionReloggerLib.Interfaces.RelogWorkers
{
    public class KillWorker : IRelogWorker
    {
        private bool _done;

        public bool Check(Account account)
        {
            return account.Running && account.PID != uint.MaxValue && account.PID != 0;
        }

        public IRelogWorker DoWork(Account account)
        {
            if (Check(account))
            {
                try
                {
                    _done = GW2MinionLauncher.KillInstance(account.PID);
                }
                catch (Exception ex)
                {
                    Logger.LoggingObject.Log(ELogType.Error, ex.Message);
                }
            }
            return this;
        }

        public void Update(Account account)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(ETranslations.KillWorkerStoppingProcess),
                                     account.PID);
            account.SetLastStopTime(DateTime.Now);
        }

        public bool PostWork(Account account)
        {
            return _done;
        }
    }
}