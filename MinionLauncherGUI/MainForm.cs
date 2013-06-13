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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using MetroFramework.Forms;
using MinionLauncherGUI.CustomControls;
using MinionLauncherGUI.Helpers;
using MinionLauncherGUI.VersionControl;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Core;
using MinionReloggerLib.CustomEventArgs;
using MinionReloggerLib.Helpers.Input;
using MinionReloggerLib.Interfaces.Objects;
using MinionReloggerLib.Logging;

namespace MinionLauncherGUI
{
    public delegate void ReloggerHandler(object sender, ReloggerEventArgs reloggerEventArgs);

    public partial class MainForm : MetroForm
    {
        internal readonly List<AccountControl> AccountControls = new List<AccountControl>();

        private int _newSet;
        private int _totalAccounts;

        public MainForm()
        {
            InitializeComponent();
            Logger.Initialize(lstBoxLog);
            ComponentManager.Singleton.LoadComponents();
            ThreadManager.Singleton.Initialize();
            PopulateGlobalSettings();
            CycleTabsForRenderer();
            if (!LoadConfig(false) || !File.Exists(Config.Singleton.GeneralSettings.GW2Path))
                SetGW2Path();
            VersionChecker.CheckForUpdates(this);
        }

        private void MetroTileStartAllClick(object sender, EventArgs e)
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(true);
            }
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (
                    object control in
                        page.Controls.Cast<object>()
                            .Where(control => control as MetroLabel != null && ((MetroLabel) control).Text == "Disabled")
                    )
                {
                    ((MetroLabel) control).Text = "Enabled";
                }
            }
        }

        private void MetroTileStopAllClick(object sender, EventArgs e)
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                account.SetShouldBeRunning(false);
                foreach (TabPage page in metroTabControl2.TabPages)
                {
                    foreach (
                        object control in
                            page.Controls.Cast<object>()
                                .Where(
                                    control => control as MetroLabel != null && ((MetroLabel) control).Text == "Enabled")
                        )
                    {
                        ((MetroLabel) control).Text = "Disabled";
                    }
                }
            }
            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }

        private void MetroTileChangeThemeClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> themes = MetroStyleManager.Styles.Themes.Keys;
            while (true)
            {
                string newTheme = themes.ElementAt(rng.Next(themes.Count));
                if (newTheme == metroStyleManager.Theme) continue;
                metroStyleManager.Theme = newTheme;
                Config.Singleton.GeneralSettings.SetTheme(newTheme);
                metroStyleManager.Update();
                break;
            }

            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }

        private void MetroTileChangeColorClick(object sender, EventArgs e)
        {
            var rng = new Random();
            ICollection<string> styles = MetroStyleManager.Styles.Styles.Keys;
            while (true)
            {
                string newStyle = styles.ElementAt(rng.Next(styles.Count));
                if (newStyle == metroStyleManager.Style || newStyle == "White") continue;
                metroStyleManager.Style = newStyle;
                Config.Singleton.GeneralSettings.SetStyle(metroStyleManager.Style);
                break;
            }

            foreach (TabPage page in metroTabControl2.TabPages)
            {
                foreach (object control in page.Controls)
                {
                    if (control as MetroControlBase != null)
                    {
                        ((MetroControlBase) control).Theme = metroStyleManager.Theme;
                        ((MetroControlBase) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroButton != null)
                    {
                        ((MetroButton) control).Theme = metroStyleManager.Theme;
                        ((MetroButton) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroLabel != null)
                    {
                        ((MetroLabel) control).Theme = metroStyleManager.Theme;
                        ((MetroLabel) control).Style = metroStyleManager.Style;
                    }
                    else if (control as MetroComboBox != null)
                    {
                        ((MetroComboBox) control).Theme = metroStyleManager.Theme;
                        ((MetroComboBox) control).Style = metroStyleManager.Style;
                    }
                }
            }
        }


        private void BtnSettingsClick(object sender, EventArgs e)
        {
            if (metroComboBoxGlobalSettingsComponents.SelectedIndex != -1)
                ComponentManager.Singleton.OpenSettingsForm(
                    ComponentManager.Singleton.GetGlobalSettingsComponentNames()[
                        metroComboBoxGlobalSettingsComponents.SelectedIndex]);
        }

        private void MetroToggleMinimizeGW2CheckedChanged(object sender, EventArgs e)
        {
            Config.Singleton.GeneralSettings.SetMinimizeWindows(metroToggleMinimizeGW2.Checked);
        }

        private void BtnLoadClick(object sender, EventArgs e)
        {
            LoadConfig(true);
        }

        private void BtnSaveClick(object sender, EventArgs e)
        {
            Config.SaveSettingsToFile();
        }

        private void BtnSetExePathClick(object sender, EventArgs e)
        {
            SetGW2Path(Config.Singleton.GeneralSettings.GW2Path);
        }

        private void BtnSetPollingDelayClick(object sender, EventArgs e)
        {
            SetPollingDelay(false, Config.Singleton.GeneralSettings.PollingDelay);
        }

        private void NewControlOnSettingsClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            if (((AccountControl) reloggereventargs.Control).CmbSettings.SelectedIndex != -1)
                ComponentManager.Singleton.OpenSettingsForm(
                    ComponentManager.Singleton.GetAccountSettingsComponentNames()[
                        ((AccountControl) reloggereventargs.Control).CmbSettings.SelectedIndex],
                    reloggereventargs.Account);
        }

        private void BtnAddAccountClick(object sender, EventArgs e)
        {
            new AccountForm(EAccountManagementType.Add).ShowDialog();
            CleanupFirstTab();
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            UpdateFormWithAccountSettings();
        }

        private void NewControlOnKillClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            reloggereventargs.Account.SetShouldBeRunning(false);
            ((AccountControl) reloggereventargs.Control).LblStatus.Text = "Disabled";
        }

        private void NewControlOnStartClick(object sender, ReloggerEventArgs reloggereventargs)
        {
            reloggereventargs.Account.SetShouldBeRunning(true);
            ((AccountControl) reloggereventargs.Control).LblStatus.Text = "Enabled";
        }

        private void NewControlOnManageClick(object sender, ReloggerEventArgs reloggerEventArgs)
        {
            new AccountForm(EAccountManagementType.Edit, reloggerEventArgs.Account).ShowDialog();
            CleanupFirstTab();
            metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
            metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
            metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
            UpdateFormWithAccountSettings();
        }

        private void CycleTabsForRenderer()
        {
            metroTabPage1.Controls.Add(new MetroLabel
                {
                    FontWeight = MetroFontWeight.Bold,
                    Text = "Login Name",
                    Theme = metroStyleManager.Theme,
                    Style = metroStyleManager.Style,
                    Location = new Point(3, 10),
                    BackColor = Color.Transparent,
                });

            metroTabPage1.Controls.Add(new MetroLabel
                {
                    FontWeight = MetroFontWeight.Bold,
                    Text = "Status",
                    Theme = metroStyleManager.Theme,
                    Style = metroStyleManager.Style,
                    Location = new Point(490, 10),
                    BackColor = Color.Transparent,
                });

            metroTabControl1.SelectTab(0);
            metroTabControl1.SelectTab(1);
            metroTabControl1.SelectTab(2);
            metroTabControl1.SelectTab(0);
        }

        private void PopulateGlobalSettings()
        {
            metroComboBoxGlobalSettingsComponents.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetGlobalSettingsComponentNames())
            {
                metroComboBoxGlobalSettingsComponents.Items.Add(component);
            }
            if (metroComboBoxGlobalSettingsComponents.Items.Count > 0)
            {
                metroComboBoxGlobalSettingsComponents.SelectedIndex = 0;
            }
        }

        private void SetGW2Path(string path = "")
        {
            var openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "Guild Wars 2 Executables (.exe)|GW2.exe|Executables (.exe)|*.exe";
            if (path != "")
                openFileDialog.InitialDirectory = path;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;

            MessageBox.Show("Please locate your GW2 executable.", "Locate GW2 Executable");
            while (
                openFileDialog.ShowDialog() !=
                DialogResult.OK || !File.Exists(openFileDialog.FileName)) ;
            Config.Singleton.GeneralSettings.SetGW2Path(openFileDialog.FileName);
        }

        private void SetPollingDelay(bool mustBeEntered = true, int currentValue = 0)
        {
            int final;
            string result = currentValue == 0 ? @"3" : currentValue.ToString();
            var dialogResult = DialogResult.OK;
            bool done = false;
            while ((!Int32.TryParse(result, out final) || final < 3 || !done) &&
                   (dialogResult == DialogResult.OK || mustBeEntered))
            {
                dialogResult = InputBox.ShowInputBox("Polling Delay",
                                                     "Please enter the desired polling delay (!minimum: 3, in seconds!).",
                                                     ref result);
                done = true;
            }

            if (dialogResult == DialogResult.OK)
                Config.Singleton.GeneralSettings.SetPollingDelay(final);
        }


        private bool LoadConfig(bool manual)
        {
            if (Config.LoadConfig(manual))
            {
                CleanupFirstTab();
                metroStyleManager.Style = Config.Singleton.GeneralSettings.StyleSetting;
                metroStyleManager.Theme = Config.Singleton.GeneralSettings.ThemeSetting;
                metroToggleMinimizeGW2.Checked = Config.Singleton.GeneralSettings.MinimizeWindows;
                UpdateFormWithAccountSettings();
                return true;
            }
            return false;
        }

        private void CreateCustomControlForLauncher(Account account)
        {
            _newSet++;
            var newControl = new AccountControl(metroTabControl2,
                                                AccountControls.Count,
                                                _totalAccounts, _newSet, metroStyleManager, account);
            newControl.StartClick += NewControlOnStartClick;
            newControl.KillClick += NewControlOnKillClick;
            newControl.ManageClick += NewControlOnManageClick;
            newControl.SettingsClick += NewControlOnSettingsClick;
            PopulateAccountSettings(newControl.CmbSettings);
            AccountControls.Add(newControl);
            _totalAccounts++;
            if (_newSet == 10)
            {
                _newSet = 0;
            }
            metroStyleManager.Update();
        }

        private void PopulateAccountSettings(MetroComboBox control)
        {
            control.Items.Clear();
            foreach (string component in ComponentManager.Singleton.GetAccountSettingsComponentNames())
            {
                control.Items.Add(component);
            }
            if (control.Items.Count > 0)
            {
                control.SelectedIndex = 0;
            }
        }

        private void CleanupFirstTab()
        {
            if (_totalAccounts > 0)
            {
                for (int i = 1; i < metroTabControl2.TabPages.Count; i++)
                {
                    metroTabControl2.TabPages.Remove(metroTabControl2.TabPages[i]);
                    i = i - 1;
                }
                metroTabPage1.Controls.Clear();
                metroTabPage1.Controls.Add(new MetroLabel
                    {
                        FontWeight = MetroFontWeight.Bold,
                        Text = "Login Name",
                        Theme = metroStyleManager.Theme,
                        Style = metroStyleManager.Style,
                        Location = new Point(3, 10),
                        BackColor = Color.Transparent,
                    });

                metroTabPage1.Controls.Add(new MetroLabel
                    {
                        FontWeight = MetroFontWeight.Bold,
                        Text = "Status",
                        Theme = metroStyleManager.Theme,
                        Style = metroStyleManager.Style,
                        Location = new Point(490, 10),
                        BackColor = Color.Transparent,
                    });
                _newSet = 0;
                _totalAccounts = 0;
                AccountControls.Clear();
            }
        }

        private void UpdateFormWithAccountSettings()
        {
            foreach (Account account in Config.Singleton.AccountSettings)
            {
                CreateCustomControlForLauncher(account);
            }
        }
    }
}