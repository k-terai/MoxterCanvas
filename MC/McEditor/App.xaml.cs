// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.


using McEditor.Commands;
using McEdShare.CoreSystem;
using McEdShare.LocalizationSystem;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace McEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            EditorCommand.Initialize();
            LocalizationManager.Initialize();

            if (e.Args.Length == 0)
            {
                EditorCommand.OpenProjectWizardCommand.Execute(null);
                return;
            }

            foreach (var s in e.Args)
            {
                if (s.Contains(EditorConsts.PROJECT_DATA_EXTENSION)) //[ProjectFile] path.
                {
                    if (EditorManager.Startup(s))
                    {
                        StartupUri = new Uri("Windows/Main/MainWindow.xaml", UriKind.RelativeOrAbsolute);
                    }
                    else
                    {
                        EditorCommand.OpenProjectWizardCommand.Execute(null);
                    }
                }
            }
        }
    }
}
