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

namespace BasicStartComponent
{
    public class BasicStartComponent : IRelogComponent, IRelogComponentExtension
    {
        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            if (Check(account))
            {
               // result = EComponentResult.Continue;
              //  if (IsReady(account))
               // {
                    Update(account);
                    result = EComponentResult.Start;
              //  }
            }
            else
            {
                result = EComponentResult.Ignore;
            }
            return this;
        }

        public string GetName()
        {
            return "BasicStartComponent";
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
            return new Form();
        }

        public ESettingsType GetSettingType()
        {
            return ESettingsType.None;
        }

        public bool Check(Account account)
        {
            return !account.Running && account.ShouldBeRunning;
        }

        public bool IsReady(Account account)
        {
            return !account.EnableScheduling || ((DateTime.Now - account.StartTime).TotalSeconds > 0 &&
                                                 (DateTime.Now - account.EndTime).TotalSeconds < 0);
        }

        public void Update(Account account)
        {
            account.Update();
        }

        public void PostWork(Account account)
        {
        }
    }
}