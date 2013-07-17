/*****************************************************************************
*                                                                            *
*  MinionReloggerLib 0.x Beta  -- https://github.com/Vipeax/MinionRelogger   *
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
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;
using MinionReloggerLib.Imports;

namespace MinionReloggerLib.Helpers.VersionControl
{
    public static class VersionControl
    {
        public static bool CheckVersion()
        {
            const string remoteUri = "http://patcher.gw2.mmominion.com/Gw2MinionFiles/";
            const string fileName = "GameVersion.txt";
            try
            {
                var myWebClient = new WebClient
                {
                    Proxy = null,
                    CachePolicy =
                        new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
                };
                uint minionVersion = Convert.ToUInt32(myWebClient.DownloadString(remoteUri + fileName));
                uint apiVer = GW2MinionLauncher.BuildNumberFromApi();
                if (minionVersion != apiVer)
                {
                    MessageBox.Show("Minion version does not match game version!\nPlease wait for an update.");
                    return false;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("Minion version does not match game version!\nPlease wait for an update.");
                return false;
            }
        }
    }
}