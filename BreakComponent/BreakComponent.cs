﻿/*****************************************************************************
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

using MinionReloggerLib.Enums;
using MinionReloggerLib.Interfaces;
using MinionReloggerLib.Interfaces.Objects;

namespace BreakComponent
{
    public class BreakComponent : IRelogComponent, IRelogComponentExtension
    {
        private bool _isEnabled;

        public IRelogComponent DoWork(Account account, ref EComponentResult result)
        {
            if (Check(account))
            {
                result = EComponentResult.Continue;
                Update(account);
            }
            else if (IsReady(account) && account.Running)
            {
                result = EComponentResult.Kill;
            }
            else if (IsReady(account))
            {
                result = EComponentResult.Halt;
            }
            else
            {
                result = EComponentResult.Ignore;
            }
            return this;
        }

        public string GetName()
        {
            return "BreakComponent";
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

        public bool Check(Account account)
        {
            return account.Running && account.BreakObject != null && account.BreakObject.Check() &&
                   account.BreakObject.IsReady();
        }

        public bool IsReady(Account account)
        {
            return account.BreakObject != null && (account.BreakObject.Check() && !account.BreakObject.IsReady());
        }

        public void Update(Account account)
        {
            account.BreakObject.Update();
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