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

namespace MinionReloggerLib.Enums
{
    public enum ETranslations
    {
        // class: BreakObject
        BreakObjectExpired,
        BreakObjectNew,

        // class: ComponentManager
        ComponentManagerAddedComponent,
        ComponentManagerEnableComponent,
        ComponentManagerDisableComponent,

        // class: Config
        ConfigNewAccount,
        ConfigErrorDuringEncryption,
        ConfigOldSaveFileDeleted,
        ConfigCouldntFindValidSaveFile,
        ConfigDumpIntegers,

        // class: DataProtector
        DataProtectorErrorOccured,
        DataProtectorDeletedSaveFile,

        // class: General Settings
        GeneralSettingsGW2PathChanged,
        GeneralSettingsPollingDelayChanged,
        GeneralSettingsFrozenTimeChanged,
        GeneralSettingsLaunchDelayChanged,
        GeneralSettingsRestartDelayChanged,
        GeneralSettingsColorChanged,
        GeneralSettingsThemeChanged,
        GeneralSettingsMinimizeWindowsChanged,
        GeneralSettingsCheckForIPChanged,
        GeneralSettingsAddedIP,
        GeneralSettingsDeletedIP,

        // class: GW2ManagerThread
        GW2ManagerThreadStoppedResponding,
        GW2ManagerThreadStartedRespondingAgain,

        // class: InputBox
        InputBoxOk,
        InputBoxCancel,

        // class: KillWorker
        KillWorkerStoppingProcess,

        // class: StartWorker
        StartWorkerScanningForExisting,
        StartWorkerLaunchingInstance,
        StartWorkerFoundWantedProcess,
        StartWorkerAttachingTo,

        // class: ViewStateObject
        ViewStateObjectClientStuckSomewhere,

        // class: WatchObject
        WatchObjectNotRespondingFor,
    }
}