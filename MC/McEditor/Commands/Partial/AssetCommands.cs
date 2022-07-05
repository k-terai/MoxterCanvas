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
        public static DelegateCommand CreateNewCanvasCommand { get; set; }

        public static void InitAssetCommands()
        {
            CreateNewCanvasCommand = new DelegateCommand((object p) =>
            {
                
            });
        }
    }
}
