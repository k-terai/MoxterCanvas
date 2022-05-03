// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Utilities
{
    public interface ISaveFileDialog
    {
        /// <summary>
        /// Show dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="filter">Save file filter.</param>
        /// <returns>Save file path.</returns>
        string ShowFileDialog(string title, string filter);
    }
}
