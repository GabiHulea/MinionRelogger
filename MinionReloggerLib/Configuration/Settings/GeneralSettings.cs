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

using System.Collections.Generic;
using System.Linq;
using System.Net;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;
using MinionReloggerLib.Logging;
using ProtoBuf;

namespace MinionReloggerLib.Configuration.Settings
{
    [ProtoContract]
    public class GeneralSettings
    {
        public List<IPAddress> AllowedIPAddresses = new List<IPAddress>();
        [ProtoMember(7)] public List<string> AllowedIPAddressesAsString = new List<string>();

        public GeneralSettings()
        {
            GW2Path = "";
            PollingDelay = 3000;
            LaunchDelay = 20000;
            RestartDelay = 300;
        }

        [ProtoMember(1)]
        public string GW2Path { get; private set; }

        [ProtoMember(2)]
        public int PollingDelay { get; private set; }

        [ProtoMember(3)]
        public int StyleSetting { get; private set; }

        [ProtoMember(4)]
        public int ThemeSetting { get; private set; }

        [ProtoMember(5)]
        public bool MinimizeWindows { get; private set; }

        [ProtoMember(6)]
        public int LaunchDelay { get; private set; }

        [ProtoMember(8)]
        public bool CheckForIP { get; private set; }

        [ProtoMember(9)]
        public int RestartDelay { get; private set; }

        public void SetGW2Path(string newPath)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsGW2PathChanged), newPath);
            GW2Path = newPath;
        }

        public void SetPollingDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsPollingDelayChanged), newDelay);
            PollingDelay = newDelay;
        }

        public void SetLaunchDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsLaunchDelayChanged), newDelay);
            LaunchDelay = newDelay;
        }

        public void SetRestartDelay(int newDelay)
        {
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsRestartDelayChanged), newDelay);
            RestartDelay = newDelay;
        }

    public void SetMinimizeWindows(bool newMinimize)
        {
            MinimizeWindows = newMinimize;
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsMinimizeWindowsChanged), newMinimize);
        }

        public void AddIP(IPAddress newAddress)
        {
            AllowedIPAddresses.Add(newAddress);
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsAddedIP),
                                     newAddress.ToString());
        }

        public void DeleteIP(IPAddress toDeleteAddress)
        {
            IPAddress wanted = AllowedIPAddresses.FirstOrDefault(ip => ip.Equals(toDeleteAddress));
            if (wanted == null)
                return;
            AllowedIPAddresses.Remove(wanted);
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(ETranslations.GeneralSettingsDeletedIP),
                                     toDeleteAddress.ToString());
        }

        public void SetCheckForIP(bool newValue)
        {
            CheckForIP = newValue;
            Logger.LoggingObject.Log(ELogType.Info,
                                     LanguageManager.Singleton.GetTranslation(
                                         ETranslations.GeneralSettingsCheckForIPChanged), newValue);
        }
    }
}