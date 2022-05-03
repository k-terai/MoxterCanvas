// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Utilities
{
    public interface IExplorerWindow : IWindow
    {
        /// <summary>
        /// Show explorer window.
        /// </summary>
        /// <param name="path">File or directory absolute path.</param>
        void ShowWindow(string path);
    }
}
