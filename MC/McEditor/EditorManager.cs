// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEditor.Controls;
using McEditor.Utilities;
using McEditor.Utilities.Folder;
using McEditor.Windows.Project;
using McEdShare.ProjectSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace McEditor
{
    public static class EditorManager
    {
        public static bool Startup(string projectpath)
        {
            if (Project.Load(projectpath) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Editor shutdown.
        /// </summary>
        /// <returns>Return true if shutdown successed.</returns>
        public static bool Shutdown()
        {
            Application.Current.Shutdown();
            return true;
        }

        public static void Restart(string projectpath)
        {
            Assembly asm = Assembly.GetEntryAssembly();

            var exes = new FileInfo(asm.Location).Directory.GetFiles("*.exe", SearchOption.TopDirectoryOnly);

            if (exes.Length != 0)
            {
                Process.Start(exes[0].FullName, projectpath);
                Application.Current.Shutdown();
            }
        }

        public static ICanvasControl CreateCanvasControl()
        {
            return new CanvasControl();
        }

        public static ISaveFileDialog CreateSaveFileDialog()
        {
            return new SaveFileDialog();
        }

        public static ISelectExternalFileWindow CreateSelectExternalFileWindow()
        {
            return new SelectExternalFileWindow();
        }

        public static ISelectExternalFolderWindow CreateSelectExternalFolderWindow()
        {
            return new SelectExternalFolderWindow();
        }

        public static IExplorerWindow CreateExplorerWindow()
        {
            return new ExplorerWindow();
        }

        public static IProjectWizard CreateProjectWizard()
        {
            return new ProjectWizard();
        }

        public static IStartControl CreateStartControl()
        {
            return new StartControl();
        }
    }
}
