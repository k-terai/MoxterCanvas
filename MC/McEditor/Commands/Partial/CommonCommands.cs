// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace McEditor.Commands
{
    public static partial class EditorCommand
    {
        public static DelegateCommand ExitCommand { get; private set; }

        public static void InitCommonCommands()
        {
            ExitCommand = new DelegateCommand(

            (object p) =>
            {
                EditorManager.Shutdown();
            }
            ,
            (object p) =>
            {
                return Application.Current.MainWindow != null;
            }

            );

            AllCommands["ExitCommand"] = ExitCommand;

        }
    }
}
