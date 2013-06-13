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
using System.Windows.Forms;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;

namespace SchedulerComponent
{
    public class SchedulerComponent : IRelogComponent, IRelogComponentExtension
    {
        private bool _isEnabled;

        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            if (Check(account))
            {
                result = EComponentResult.Continue;
                if (IsReady(account))
                {
                    Update(account);
                    result = EComponentResult.Kill;
                }
            }
            else
            {
                result = EComponentResult.Ignore;
            }
            return this;
        }

        public string GetName()
        {
            return "SchedulerComponent";
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void OnLoad()
        {
        }

        public void OnUnload()
        {
        }

        public Form ShowSettingsForm(Account account = null)
        {
            return new SettingsForm(account);
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.AccountSpecific;
        }

        public bool Check(Account account)
        {
            return account.EnableScheduling;
        }

        public bool IsReady(Account account)
        {
            double differenceFuture = (DateTime.Now - account.EndTime).TotalSeconds;
            double differencePast = (account.StartTime - DateTime.Now).TotalSeconds;
            return account.Running && (differenceFuture > 0 || differencePast > 0);
        }

        public void Update(Account account)
        {
            account.Update();
        }

        public void PostWork(Account account)
        {
        }

        public bool IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }
    }
}