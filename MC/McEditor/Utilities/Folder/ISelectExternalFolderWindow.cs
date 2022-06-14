// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Utilities.Folder
{
    public interface ISelectExternalFolderWindow : IWindow
    {
        /// <summary>
        /// Show window.
        /// </summary>
        /// <param name="description">Window title.</param>
        /// <returns>Select folder path.</returns>
        string ShowWindow(string description);

        /// <summary>
        /// Show window.
        /// </summary>
        /// <param name="description">Window title.</param>
        /// <param name="selectedpath">Specify the first folder to select.</param>
        /// <param name="shownewfolderbutton">True = allow user to create new folder</param>
        /// <returns>Select folder path.</returns>
        string ShowWindow(string description, string selectedpath, bool shownewfolderbutton);
    }
}
