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

using MetroFramework.Forms;
using MinionReloggerLib.Enums;
using MinionReloggerLib.Helpers.Language;

namespace MinionLauncherGUI
{
    partial class MainForm : MetroForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pctBoxLogo = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.metroTabControl2 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSetLanguage = new MetroFramework.Controls.MetroButton();
            this.metroComboBox3 = new MetroFramework.Controls.MetroComboBox();
            this.btnSetFrozenTime = new MetroFramework.Controls.MetroButton();
            this.btnEnableComponent = new MetroFramework.Controls.MetroButton();
            this.btnDisableComponent = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.btnAddAccount = new MetroFramework.Controls.MetroButton();
            this.btnSetPollingDelay = new MetroFramework.Controls.MetroButton();
            this.btnLoad = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroComboBoxGlobalSettingsComponents = new MetroFramework.Controls.MetroComboBox();
            this.btnSettings = new MetroFramework.Controls.MetroButton();
            this.metroToggleMinimizeGW2 = new MetroFramework.Controls.MetroToggle();
            this.btnSetExePath = new MetroFramework.Controls.MetroButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lstBoxLog = new System.Windows.Forms.ListBox();
            this.metroStyleManager = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroTileStartAll = new MetroFramework.Controls.MetroTile();
            this.metroTileStopAll = new MetroFramework.Controls.MetroTile();
            this.metroTileChangeTheme = new MetroFramework.Controls.MetroTile();
            this.metroTileChangeColor = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroToggle1 = new MetroFramework.Controls.MetroToggle();
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.metroTabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).BeginInit();
            this.SuspendLayout();
            // 
            // pctBoxLogo
            // 
            this.pctBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pctBoxLogo.Image = global::MinionLauncherGUI.Properties.Resources.logo;
            this.pctBoxLogo.InitialImage = global::MinionLauncherGUI.Properties.Resources.logo;
            this.pctBoxLogo.Location = new System.Drawing.Point(14, 20);
            this.pctBoxLogo.Name = "pctBoxLogo";
            this.pctBoxLogo.Size = new System.Drawing.Size(326, 72);
            this.pctBoxLogo.TabIndex = 0;
            this.pctBoxLogo.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.Controls.Add(this.tabPage3);
            this.metroTabControl1.Location = new System.Drawing.Point(23, 109);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(941, 520);
            this.metroTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.metroTabControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(933, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Accounts";
            // 
            // metroTabControl2
            // 
            this.metroTabControl2.Controls.Add(this.metroTabPage1);
            this.metroTabControl2.Location = new System.Drawing.Point(5, 6);
            this.metroTabControl2.Name = "metroTabControl2";
            this.metroTabControl2.SelectedIndex = 0;
            this.metroTabControl2.Size = new System.Drawing.Size(925, 482);
            this.metroTabControl2.TabIndex = 0;
            this.metroTabControl2.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 25);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(917, 453);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "1-10";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.metroLabel1);
            this.tabPage2.Controls.Add(this.metroToggle1);
            this.tabPage2.Controls.Add(this.btnSetLanguage);
            this.tabPage2.Controls.Add(this.metroComboBox3);
            this.tabPage2.Controls.Add(this.btnSetFrozenTime);
            this.tabPage2.Controls.Add(this.btnEnableComponent);
            this.tabPage2.Controls.Add(this.btnDisableComponent);
            this.tabPage2.Controls.Add(this.metroLabel4);
            this.tabPage2.Controls.Add(this.metroLabel3);
            this.tabPage2.Controls.Add(this.metroComboBox2);
            this.tabPage2.Controls.Add(this.metroComboBox1);
            this.tabPage2.Controls.Add(this.btnAddAccount);
            this.tabPage2.Controls.Add(this.btnSetPollingDelay);
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.metroLabel2);
            this.tabPage2.Controls.Add(this.metroComboBoxGlobalSettingsComponents);
            this.tabPage2.Controls.Add(this.btnSettings);
            this.tabPage2.Controls.Add(this.metroToggleMinimizeGW2);
            this.tabPage2.Controls.Add(this.btnSetExePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(933, 491);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // btnSetLanguage
            // 
            this.btnSetLanguage.Location = new System.Drawing.Point(402, 233);
            this.btnSetLanguage.Name = "btnSetLanguage";
            this.btnSetLanguage.Size = new System.Drawing.Size(112, 23);
            this.btnSetLanguage.TabIndex = 21;
            this.btnSetLanguage.Text = "Set Language";
            this.btnSetLanguage.Click += new System.EventHandler(this.BtnSetLanguageClick);
            // 
            // metroComboBox3
            // 
            this.metroComboBox3.FormattingEnabled = true;
            this.metroComboBox3.ItemHeight = 23;
            this.metroComboBox3.Location = new System.Drawing.Point(152, 231);
            this.metroComboBox3.MaxDropDownItems = 15;
            this.metroComboBox3.Name = "metroComboBox3";
            this.metroComboBox3.Size = new System.Drawing.Size(234, 29);
            this.metroComboBox3.TabIndex = 20;
            // 
            // btnSetFrozenTime
            // 
            this.btnSetFrozenTime.Location = new System.Drawing.Point(402, 161);
            this.btnSetFrozenTime.Name = "btnSetFrozenTime";
            this.btnSetFrozenTime.Size = new System.Drawing.Size(112, 23);
            this.btnSetFrozenTime.TabIndex = 19;
            this.btnSetFrozenTime.Text = "Set Frozen Time";
            this.btnSetFrozenTime.Click += new System.EventHandler(this.BtnSetFrozenTimeClick);
            // 
            // btnEnableComponent
            // 
            this.btnEnableComponent.Location = new System.Drawing.Point(531, 365);
            this.btnEnableComponent.Name = "btnEnableComponent";
            this.btnEnableComponent.Size = new System.Drawing.Size(112, 23);
            this.btnEnableComponent.TabIndex = 18;
            this.btnEnableComponent.Text = "Move To Left";
            this.btnEnableComponent.Click += new System.EventHandler(this.BtnEnableComponentClick);
            // 
            // btnDisableComponent
            // 
            this.btnDisableComponent.Location = new System.Drawing.Point(274, 365);
            this.btnDisableComponent.Name = "btnDisableComponent";
            this.btnDisableComponent.Size = new System.Drawing.Size(112, 23);
            this.btnDisableComponent.TabIndex = 17;
            this.btnDisableComponent.Text = "Move To Right";
            this.btnDisableComponent.Click += new System.EventHandler(this.BtnDisableComponentClick);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.Drawing.MetroFontSize.Medium;
            this.metroLabel4.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(535, 307);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(155, 19);
            this.metroLabel4.TabIndex = 16;
            this.metroLabel4.Text = "Disabled Components";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.Drawing.MetroFontSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.Drawing.MetroFontWeight.Bold;
            this.metroLabel3.Location = new System.Drawing.Point(155, 307);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(150, 19);
            this.metroLabel3.TabIndex = 15;
            this.metroLabel3.Text = "Enabled Components";
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 23;
            this.metroComboBox2.Location = new System.Drawing.Point(531, 328);
            this.metroComboBox2.MaxDropDownItems = 15;
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.Size = new System.Drawing.Size(234, 29);
            this.metroComboBox2.TabIndex = 14;
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 23;
            this.metroComboBox1.Location = new System.Drawing.Point(152, 328);
            this.metroComboBox1.MaxDropDownItems = 15;
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.Size = new System.Drawing.Size(234, 29);
            this.metroComboBox1.TabIndex = 13;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(402, 20);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(112, 23);
            this.btnAddAccount.TabIndex = 12;
            this.btnAddAccount.Text = "Add Account";
            this.btnAddAccount.Click += new System.EventHandler(this.BtnAddAccountClick);
            // 
            // btnSetPollingDelay
            // 
            this.btnSetPollingDelay.Location = new System.Drawing.Point(402, 127);
            this.btnSetPollingDelay.Name = "btnSetPollingDelay";
            this.btnSetPollingDelay.Size = new System.Drawing.Size(112, 23);
            this.btnSetPollingDelay.TabIndex = 11;
            this.btnSetPollingDelay.Text = "Set Polling Delay";
            this.btnSetPollingDelay.Click += new System.EventHandler(this.BtnSetPollingDelayClick);
            // 
            // btnLoad
            // 
            this.btnLoad.Highlight = true;
            this.btnLoad.Location = new System.Drawing.Point(401, 421);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 23);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load";
            this.btnLoad.Click += new System.EventHandler(this.BtnLoadClick);
            // 
            // btnSave
            // 
            this.btnSave.Highlight = true;
            this.btnSave.Location = new System.Drawing.Point(401, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(242, 198);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(158, 19);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Minimize GW2 Windows?";
            // 
            // metroComboBoxGlobalSettingsComponents
            // 
            this.metroComboBoxGlobalSettingsComponents.FormattingEnabled = true;
            this.metroComboBoxGlobalSettingsComponents.ItemHeight = 23;
            this.metroComboBoxGlobalSettingsComponents.Location = new System.Drawing.Point(152, 52);
            this.metroComboBoxGlobalSettingsComponents.MaxDropDownItems = 15;
            this.metroComboBoxGlobalSettingsComponents.Name = "metroComboBoxGlobalSettingsComponents";
            this.metroComboBoxGlobalSettingsComponents.Size = new System.Drawing.Size(234, 29);
            this.metroComboBoxGlobalSettingsComponents.TabIndex = 6;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(401, 55);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(112, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Open Settings";
            this.btnSettings.Click += new System.EventHandler(this.BtnSettingsClick);
            // 
            // metroToggleMinimizeGW2
            // 
            this.metroToggleMinimizeGW2.AutoSize = true;
            this.metroToggleMinimizeGW2.Location = new System.Drawing.Point(414, 200);
            this.metroToggleMinimizeGW2.Name = "metroToggleMinimizeGW2";
            this.metroToggleMinimizeGW2.Size = new System.Drawing.Size(80, 17);
            this.metroToggleMinimizeGW2.TabIndex = 7;
            this.metroToggleMinimizeGW2.Text = "Off";
            this.metroToggleMinimizeGW2.CheckedChanged += new System.EventHandler(this.MetroToggleMinimizeGW2CheckedChanged);
            // 
            // btnSetExePath
            // 
            this.btnSetExePath.Location = new System.Drawing.Point(401, 92);
            this.btnSetExePath.Name = "btnSetExePath";
            this.btnSetExePath.Size = new System.Drawing.Size(112, 23);
            this.btnSetExePath.TabIndex = 6;
            this.btnSetExePath.Text = "Set GW2 EXE Path";
            this.btnSetExePath.Click += new System.EventHandler(this.BtnSetExePathClick);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.lstBoxLog);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(933, 491);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            // 
            // lstBoxLog
            // 
            this.lstBoxLog.FormattingEnabled = true;
            this.lstBoxLog.Location = new System.Drawing.Point(3, 4);
            this.lstBoxLog.Name = "lstBoxLog";
            this.lstBoxLog.Size = new System.Drawing.Size(927, 485);
            this.lstBoxLog.TabIndex = 0;
            // 
            // metroStyleManager
            // 
            this.metroStyleManager.Owner = this;
            // 
            // metroTileStartAll
            // 
            this.metroTileStartAll.Location = new System.Drawing.Point(436, 20);
            this.metroTileStartAll.Name = "metroTileStartAll";
            this.metroTileStartAll.Size = new System.Drawing.Size(110, 103);
            this.metroTileStartAll.TabIndex = 2;
            this.metroTileStartAll.Text = " Start All";
            this.metroTileStartAll.TileImage = ((System.Drawing.Image)(resources.GetObject("metroTileStartAll.TileImage")));
            this.metroTileStartAll.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileStartAll.UseTileImage = true;
            this.metroTileStartAll.Click += new System.EventHandler(this.MetroTileStartAllClick);
            // 
            // metroTileStopAll
            // 
            this.metroTileStopAll.Location = new System.Drawing.Point(561, 20);
            this.metroTileStopAll.Name = "metroTileStopAll";
            this.metroTileStopAll.Size = new System.Drawing.Size(110, 103);
            this.metroTileStopAll.TabIndex = 3;
            this.metroTileStopAll.Text = " Stop All";
            this.metroTileStopAll.TileImage = global::MinionLauncherGUI.Properties.Resources.halt;
            this.metroTileStopAll.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileStopAll.UseTileImage = true;
            this.metroTileStopAll.Click += new System.EventHandler(this.MetroTileStopAllClick);
            // 
            // metroTileChangeTheme
            // 
            this.metroTileChangeTheme.Location = new System.Drawing.Point(686, 20);
            this.metroTileChangeTheme.Name = "metroTileChangeTheme";
            this.metroTileChangeTheme.Size = new System.Drawing.Size(110, 103);
            this.metroTileChangeTheme.TabIndex = 4;
            this.metroTileChangeTheme.Text = " Change Theme";
            this.metroTileChangeTheme.TileImage = global::MinionLauncherGUI.Properties.Resources.theme;
            this.metroTileChangeTheme.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileChangeTheme.UseTileImage = true;
            this.metroTileChangeTheme.Click += new System.EventHandler(this.MetroTileChangeThemeClick);
            // 
            // metroTileChangeColor
            // 
            this.metroTileChangeColor.Location = new System.Drawing.Point(813, 20);
            this.metroTileChangeColor.Name = "metroTileChangeColor";
            this.metroTileChangeColor.Size = new System.Drawing.Size(110, 103);
            this.metroTileChangeColor.TabIndex = 5;
            this.metroTileChangeColor.Text = " Change Color";
            this.metroTileChangeColor.TileImage = global::MinionLauncherGUI.Properties.Resources.paint;
            this.metroTileChangeColor.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTileChangeColor.UseTileImage = true;
            this.metroTileChangeColor.Click += new System.EventHandler(this.MetroTileChangeColorClick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(242, 276);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(162, 19);
            this.metroLabel1.TabIndex = 23;
            this.metroLabel1.Text = "Enable Extensive Logging?";
            // 
            // metroToggle1
            // 
            this.metroToggle1.AutoSize = true;
            this.metroToggle1.Location = new System.Drawing.Point(414, 278);
            this.metroToggle1.Name = "metroToggle1";
            this.metroToggle1.Size = new System.Drawing.Size(80, 17);
            this.metroToggle1.TabIndex = 22;
            this.metroToggle1.Text = "Off";
            this.metroToggle1.CheckedChanged += new System.EventHandler(this.MetroToggle1CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 652);
            this.Controls.Add(this.metroTileChangeColor);
            this.Controls.Add(this.metroTileChangeTheme);
            this.Controls.Add(this.metroTileStopAll);
            this.Controls.Add(this.metroTileStartAll);
            this.Controls.Add(this.pctBoxLogo);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.SystemAeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            ((System.ComponentModel.ISupportInitialize)(this.pctBoxLogo)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.metroTabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctBoxLogo;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox lstBoxLog;
        private MetroFramework.Controls.MetroTile metroTileStartAll;
        private MetroFramework.Controls.MetroTile metroTileStopAll;
        private MetroFramework.Controls.MetroTile metroTileChangeTheme;
        private MetroFramework.Controls.MetroTile metroTileChangeColor;
        private MetroFramework.Components.MetroStyleManager metroStyleManager;
        private MetroFramework.Controls.MetroComboBox metroComboBoxGlobalSettingsComponents;
        private MetroFramework.Controls.MetroButton btnSettings;
        private MetroFramework.Controls.MetroToggle metroToggleMinimizeGW2;
        private MetroFramework.Controls.MetroButton btnSetExePath;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnLoad;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroButton btnSetPollingDelay;
        private MetroFramework.Controls.MetroTabControl metroTabControl2;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton btnAddAccount;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroButton btnEnableComponent;
        private MetroFramework.Controls.MetroButton btnDisableComponent;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private MetroFramework.Controls.MetroButton btnSetFrozenTime;
        private MetroFramework.Controls.MetroButton btnSetLanguage;
        private MetroFramework.Controls.MetroComboBox metroComboBox3;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroToggle metroToggle1;
    }
}


