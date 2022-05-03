// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Utilities
{
    public sealed class ExplorerWindow : IExplorerWindow
    {
        public void ShowWindow(string path)
        {
            System.Diagnostics.Process.Start("EXPLORER.EXE", path);
        }

        public void ShowWindow()
        {
            ShowWindow(Environment.CurrentDirectory);
        }
    }
}
