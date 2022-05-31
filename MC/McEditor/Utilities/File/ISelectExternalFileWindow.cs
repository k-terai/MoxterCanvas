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
    public interface ISelectExternalFileWindow : IWindow
    {
        /// <summary>
        /// Show window.
        /// </summary>
        /// <param name="description">Window description.</param>
        /// <param name="filter">Select filter.</param>
        /// <param name="multiselect">True = Multi file select enable.</param>
        /// <returns>Select file list.</returns>
        List<string> ShowWindow(string description, string filter, bool multiselect);
    }
}
