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
using System.Diagnostics;
using MinionReloggerLib.Helpers.Encryption;
using ProtoBuf;

namespace MinionReloggerLib.Interfaces.Objects
{
    [ProtoContract]
    public class Account : IObject
    {
        [ProtoMember(1)] private string _loginName;
        [ProtoMember(2)] private string _password;

        public Account()
        {
            EnableScheduling = false;
            ManuallyScheduled = false;
            ShouldBeRunning = false;
            PID = uint.MaxValue;
            Index = 0;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now.AddYears(1);
        }

        [ProtoMember(3)]
        public bool NoSound { get; private set; }

        [ProtoMember(4)]
        public string BotPath { get; private set; }

        [ProtoMember(5)]
        public BreakObject BreakObject { get; private set; }

        [ProtoMember(6)]
        public bool EnableScheduling { get; private set; }

        [ProtoMember(7)]
        public bool ManuallyScheduled { get; private set; }

        [ProtoMember(8)]
        public DateTime StartTime { get; private set; }

        [ProtoMember(9)]
        public DateTime EndTime { get; private set; }

        public bool ShouldBeRunning { get; private set; }
        public uint PID { get; private set; }
        public int Index { get; private set; }

        public DateTime LastStart { get; private set; }
        public DateTime LastCrash { get; private set; }
        public DateTime LastStop { get; private set; }

        public string LoginName
        {
            get { return DataProtector.DecryptData(_loginName); }
            private set { _loginName = DataProtector.EncryptData(value); }
        }

        public string Password
        {
            get { return DataProtector.DecryptData(_password); }
            private set { _password = DataProtector.EncryptData(value); }
        }

        public bool Running
        {
            get
            {
                try
                {
                    return Process.GetProcessById((int) PID).Id != 0;
                }
                catch (ArgumentException)
                {
                    return false;
                }
            }
        }

        public bool Check()
        {
            return true;
        }

        public IObject DoWork()
        {
            return this;
        }

        public bool IsReady()
        {
            return true;
        }

        public void Update()
        {
        }

        public void SetNoSound(bool newNoSound)
        {
            NoSound = newNoSound;
        }

        public void SetLoginName(string newLoginName)
        {
            LoginName = newLoginName;
        }

        public void SetPassword(string newPassword)
        {
            Password = newPassword;
        }

        public void SetIndex(int newIndex)
        {
            Index = newIndex;
        }

        public void SetLastCrash(DateTime newLastCrash)
        {
            LastCrash = newLastCrash;
        }

        public void SetPID(uint newPID)
        {
            PID = newPID;
        }

        public void SetStartTime(DateTime newStartTime)
        {
            StartTime = newStartTime;
        }

        public void SetEndTime(DateTime newEndTime)
        {
            EndTime = newEndTime;
        }

        public void SetLastStartTime(DateTime newStartTime)
        {
            LastStart = newStartTime;
        }

        public void SetLastStopTime(DateTime newStopTime)
        {
            LastStop = newStopTime;
        }

        public void SetShouldBeRunning(bool newShouldBeRunning)
        {
            ShouldBeRunning = newShouldBeRunning;
        }

        public void SetManuallyScheduled(bool newManuallyScheduled)
        {
            ManuallyScheduled = newManuallyScheduled;
        }

        public void SetSchedulingEnabled(bool newSchedulingEnabled)
        {
            EnableScheduling = newSchedulingEnabled;
        }

        public void SetBotPath(string newPath)
        {
            BotPath = newPath;
        }

        public void SetBreak(BreakObject newBreak)
        {
            BreakObject = newBreak;
            BreakObject.LoginName = LoginName;
        }
    }
}