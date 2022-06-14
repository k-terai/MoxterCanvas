// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Commands
{
    public static partial class EditorCommand
    {
        public static DelegateCommand OpenProjectCommand { get; private set; }
        public static DelegateCommand OpenProjectWizardCommand { get; private set; }

        private static void InitProjectCommands()
        {
            OpenProjectCommand = new DelegateCommand(

            (object p) =>
            {
                var window = EditorManager.CreateSelectExternalFileWindow();
                var path = window.ShowWindow("Please select open project file.", "Project File(*.project) |*.project", false);
                if (path != null && path.Count != 0)
                {
                    EditorManager.Restart(path[0]);
                }
            }
            ,
            (object p) =>
            {
                return true;
            }

            );

            OpenProjectWizardCommand = new DelegateCommand(

            (object p) =>
            {
                var window = EditorManager.CreateProjectWizard();
                window.ShowWindow();
            }
            ,
            (object p) =>
            {
                return true;
            }

            );

            AllCommands["OpenProjectCommand"] = OpenProjectCommand;
            AllCommands["OpenProjectWizardCommand"] = OpenProjectWizardCommand;
        }
    }
}
