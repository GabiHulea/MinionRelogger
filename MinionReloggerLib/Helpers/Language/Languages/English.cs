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

using MinionReloggerLib.Enums;

namespace MinionReloggerLib.Helpers.Language.Languages
{
    public class English : Language
    {
        public English()
        {
            // class: BreakObject
            Translations.Add(ETranslations.BreakObjectExpired, "Break has expired for {0}, starting new cycle!");
            Translations.Add(ETranslations.BreakObjectNew, "New Start Break: {0}, New End Break: {1}.");

            // class ComponentManager
            Translations.Add(ETranslations.ComponentManagerAddedComponent,
                             "A component with the name {0} has been added to the list.");
            Translations.Add(ETranslations.ComponentManagerDisableComponent,
                             "A component with the name {0} has been disabled.");
            Translations.Add(ETranslations.ComponentManagerEnableComponent,
                             "A component with the name {0} has been enabled.");

            // class: Config
            Translations.Add(ETranslations.ConfigNewAccount, "Added new Account object.");
            Translations.Add(ETranslations.ConfigErrorDuringEncryption, "An error has occurred during data encryption!");
            Translations.Add(ETranslations.ConfigOldSaveFileDeleted,
                             "Old save file has been deleted, must have been a different version or corrupt!");
            Translations.Add(ETranslations.ConfigCouldntFindValidSaveFile,
                             "Couldn't find a valid save file. Please create a new save file.");
            Translations.Add(ETranslations.ConfigDumpIntegers,
                             "Polling Delay: {0}, Launch Delay: {1}, Restart Delay: {2}, Frozen Time: {3}.");

            // class: DataProtector
            Translations.Add(ETranslations.DataProtectorErrorOccured, "An error has occurred during data encryption!");
            Translations.Add(ETranslations.DataProtectorDeletedSaveFile,
                             "Old save file has been deleted, must have been a different version or corrupt!");

            // class: General Settings
            Translations.Add(ETranslations.GeneralSettingsGW2PathChanged, "GW2 Path has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsPollingDelayChanged,
                             "Polling delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsFrozenTimeChanged,
                             "Frozen time has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsLaunchDelayChanged, "Launch delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsRestartDelayChanged,
                             "Restart delay has been changed to: [{0}].");
            Translations.Add(ETranslations.GeneralSettingsColorChanged, "Switched to color: {0}.");
            Translations.Add(ETranslations.GeneralSettingsThemeChanged, "Switched to theme: {0}.");
            Translations.Add(ETranslations.GeneralSettingsMinimizeWindowsChanged,
                             "Minimize windows has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsCheckForIPChanged,
                             "Check for IP has been changed to: {0}.");
            Translations.Add(ETranslations.GeneralSettingsAddedIP,
                             "Added IP address {0} to the list of allowed addresses.");
            Translations.Add(ETranslations.GeneralSettingsDeletedIP,
                             "Deleted IP address {0} from the list of allowed addresses.");

            // class: GW2ManagerThread
            Translations.Add(ETranslations.GW2ManagerThreadStoppedResponding,
                             "A GW 2 instance, running {0}, has stopped responding. Keeping an eye out.");
            Translations.Add(ETranslations.GW2ManagerThreadStartedRespondingAgain,
                             "The GW 2 instance, running {0}, has started responding again.");

            // class: InputBox
            Translations.Add(ETranslations.InputBoxOk, "OK");
            Translations.Add(ETranslations.InputBoxCancel, "Cancel");

            // class: KillWorker
            Translations.Add(ETranslations.KillWorkerStoppingProcess, "Stopping process with PID {0}.");

            // class: StartWorker
            Translations.Add(ETranslations.StartWorkerLaunchingInstance, "Launching instance for {0} with {1}.");
            Translations.Add(ETranslations.StartWorkerScanningForExisting, "Scanning existing GW2 instances.");
            Translations.Add(ETranslations.StartWorkerFoundWantedProcess,
                             "Found wanted process for {0}, no need to launch.");
            Translations.Add(ETranslations.StartWorkerAttachingTo, "Attaching to {0} with {1}.");

            // class: ViewStateObject
            Translations.Add(ETranslations.ViewStateObjectClientStuckSomewhere,
                             "The GW2 instance, running {0}, has not been in-game for {1} seconds, scheduling it for a restart.");

            // class: WatchObject
            Translations.Add(ETranslations.WatchObjectNotRespondingFor,
                             "The GW 2 instance, running {0}, has not been responding for 90 seconds, scheduling it for a restart.");
        }

        public override string GetLanguageDescription()
        {
            return "English";
        }

        public override ELanguages GetLanguage()
        {
            return ELanguages.English;
        }
    }
}