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
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;

namespace RestartDelayComponent
{
    public class RestartDelayComponent : IRelogComponent, IRelogComponentExtension
    {
        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            //   if (Check(account))
          //  {
           //     result = EComponentResult.Start;
            result = IsReady(account) ? EComponentResult.Halt : EComponentResult.Ignore;
            return this;
        }

        public string GetName()
        {
            return "RestartDelayComponent";
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
            return new SettingsForm();
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.Global;
        }

        public bool Check(Account account)
        {
            return account.ShouldBeRunning && !account.Running;
        }

        public bool IsReady(Account account)
        {
            return (DateTime.Now - account.LastCrash).TotalSeconds <= Config.Singleton.GeneralSettings.RestartDelay &&
                   (DateTime.Now - account.LastStop).TotalSeconds <= Config.Singleton.GeneralSettings.RestartDelay &&
                   (DateTime.Now - account.LastStart).TotalSeconds <=
                   Config.Singleton.GeneralSettings.RestartDelay;
        }

        public void Update(Account account)
        {
        }

        public void PostWork(Account account)
        {
        }
    }
}