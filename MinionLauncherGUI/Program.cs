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
            private int _formCount;

            private MyApplicationContext()
            {
                _formCount = 0;
             
                _mainForm = new MainForm();
                _mainForm.Closed += OnFormClosed;
                _formCount++;
                
                _mainForm.Show();
            }
            
            private void OnFormClosed(object sender, EventArgs e)
            {
                _formCount--;
                if (_formCount == 0)
                {
                    ExitThread();
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