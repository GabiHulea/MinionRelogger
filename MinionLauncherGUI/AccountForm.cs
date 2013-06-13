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
using System.Linq;
using MetroFramework.Forms;
using MinionLauncherGUI.Helpers;
using MinionReloggerLib.Configuration;
using MinionReloggerLib.Interfaces.Objects;

namespace MinionLauncherGUI
{
    public partial class AccountForm : MetroForm
    {
        private readonly Account _account;
        private readonly EAccountManagementType _type;

        public AccountForm(EAccountManagementType type, Account account = null)
        {
            InitializeComponent();
            _account = account;
            _type = type;
            switch (type)
            {
                case EAccountManagementType.Add:
                    btnDelete.Visible = false;
                    Text = "Add Account";
                    break;
                case EAccountManagementType.Edit:
                    btnDelete.Visible = true;
                    Text = "Edit Account";
                    break;
            }
            if (account != null)
            {
                txtBoxLoginName.Text = account.LoginName;
                txtBoxPassword.Text = account.Password;
                metroToggle1.Checked = account.NoSound;
            }
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            switch (_type)
            {
                case EAccountManagementType.Add:
                    if (!string.IsNullOrEmpty(txtBoxLoginName.Text) && !string.IsNullOrEmpty(txtBoxPassword.Text) &&
                        Config.Singleton.AccountSettings.All(account => account.LoginName != txtBoxLoginName.Text))
                    {
                        var toAdd = new Account();
                        toAdd.SetLoginName(txtBoxLoginName.Text);
                        toAdd.SetPassword(txtBoxPassword.Text);
                        toAdd.SetBotPath(AppDomain.CurrentDomain.BaseDirectory);
                        toAdd.SetEndTime(DateTime.Now.AddYears(1337));
                        toAdd.SetManuallyScheduled(false);
                        toAdd.SetNoSound(metroToggle1.Checked);
                        Config.Singleton.AddAccount(toAdd);
                    }
                    break;
                case EAccountManagementType.Edit:
                    Account wanted =
                        Config.Singleton.AccountSettings.FirstOrDefault(
                            account => account.LoginName == _account.LoginName);
                    if (wanted != null)
                    {
                        wanted.SetPassword(txtBoxPassword.Text);
                        wanted.SetNoSound(metroToggle1.Checked);
                        wanted.SetLoginName(txtBoxLoginName.Text);
                    }
                    break;
            }
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnDeleteClick(object sender, EventArgs e)
        {
            Account wanted =
                Config.Singleton.AccountSettings.FirstOrDefault(account => account.LoginName == _account.LoginName);
            if (wanted != null)
            {
                Config.Singleton.DeleteAccount(wanted);
            }
            Close();
        }
    }
}