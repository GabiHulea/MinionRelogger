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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MinionLauncherGUI
{
    internal static class Program
    {
        private class MyApplicationContext : ApplicationContext
        {
            private readonly MainForm _mainForm;
            private readonly FileStream _userData;

            private int _formCount;
            private Rectangle _mainFormPosition;

            private MyApplicationContext()
            {
                _formCount = 0;
                Application.ApplicationExit += OnApplicationExit;

                try
                {
                    _userData = new FileStream(
                        AppDomain.CurrentDomain.BaseDirectory + "\\MinionFiles\\" + "appdata.txt", FileMode.OpenOrCreate);
                }
                catch (IOException e)
                {
                    MessageBox.Show("An error occurred while attempting to show the application." +
                                    "The error is:" + e);
                    ExitThread();
                }

                _mainForm = new MainForm();
                _mainForm.Closed += OnFormClosed;
                _mainForm.Closing += OnFormClosing;
                _formCount++;

                if (ReadFormDataFromFile())
                {
                    _mainForm.StartPosition = FormStartPosition.Manual;
                    _mainForm.Bounds = _mainFormPosition;
                }

                _mainForm.Show();
            }

            private void OnApplicationExit(object sender, EventArgs e)
            {
                WriteFormDataToFile();

                try
                {
                    _userData.Close();
                }
                catch {}
            }

            private void OnFormClosing(object sender, CancelEventArgs e)
            {
                if (sender is MainForm)
                    _mainFormPosition = ((Form) sender).Bounds;
            }

            private void OnFormClosed(object sender, EventArgs e)
            {
                _formCount--;
                if (_formCount == 0)
                {
                    ExitThread();
                }
            }

            private bool WriteFormDataToFile()
            {
                var encoding = new UTF8Encoding();

                var rectConv = new RectangleConverter();
                String mainFormPos = rectConv.ConvertToString(_mainFormPosition);

                byte[] dataToWrite = encoding.GetBytes("~" + mainFormPos);

                try
                {
                    _userData.Seek(0, SeekOrigin.Begin);
                    _userData.Write(dataToWrite, 0, dataToWrite.Length);
                    _userData.Flush();

                    _userData.SetLength(dataToWrite.Length);
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            private bool ReadFormDataFromFile()
            {
                var encoding = new UTF8Encoding();
                String data;

                if (_userData.Length != 0)
                {
                    var dataToRead = new Byte[_userData.Length];

                    try
                    {
                        _userData.Seek(0, SeekOrigin.Begin);
                        _userData.Read(dataToRead, 0, dataToRead.Length);
                    }
                    catch (IOException e)
                    {
                        String errorInfo = e.ToString();
                        return false;
                    }

                    data = encoding.GetString(dataToRead);

                    try
                    {
                        var rectConv = new RectangleConverter();
                        String mainFormPos = data.Substring(1, data.IndexOf("~", 1) - 1);

                        _mainFormPosition = (Rectangle) rectConv.ConvertFromString(mainFormPos);

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            ///     The main entry point for the application.
            /// </summary>
            [STAThread]
            private static void Main()
            {
                try
                {
                    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainAssemblyResolve;
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    var context = new MyApplicationContext();
                    Application.Run(context);
                }
                catch (Exception ex) {}
            }

            private static Assembly CurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
            {
                try
                {
                    string RMSAssemblyFolder = AppDomain.CurrentDomain.BaseDirectory + "\\MinionFiles\\";

                    Assembly MyAssembly = null;
                    string strTempAssmbPath = string.Empty;

                    Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
                    AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();

                    AssemblyName myAssemblyName = Array.Find(arrReferencedAssmbNames, a => a.Name == args.Name);

                    if (myAssemblyName != null)
                    {
                        MyAssembly = Assembly.LoadFrom(myAssemblyName.CodeBase);
                    }
                    else
                    {
                        strTempAssmbPath = Path.Combine(RMSAssemblyFolder,
                                                        args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");

                        if (!string.IsNullOrEmpty(strTempAssmbPath))
                        {
                            if (File.Exists(strTempAssmbPath))
                            {
                                MyAssembly = Assembly.LoadFrom(strTempAssmbPath);
                            }
                        }
                    }
                    return MyAssembly;
                }
                catch (Exception exc)
                {
                    return null;
                }
            }
        }
    }
}