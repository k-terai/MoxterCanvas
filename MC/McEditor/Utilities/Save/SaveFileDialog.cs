// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Utilities
{
    public sealed class SaveFileDialog : ISaveFileDialog
    {
        /// <summary>
        ///Absolute path to the most recently opened folder.
        /// </summary>
        private static string s_recentOpenDirectory = null;

        /// <summary>
        /// Show dialog.
        /// </summary>
        /// <param name="title">Dialog title.</param>
        /// <param name="filter">Save file filter.</param>
        /// <returns>Save file path.</returns>
        public string ShowFileDialog(string title, string filter)
        {
            System.Windows.Forms.SaveFileDialog sfd = new System.Windows.Forms.SaveFileDialog();


            if (s_recentOpenDirectory != null && Directory.Exists(s_recentOpenDirectory))
            {
                sfd.InitialDirectory = s_recentOpenDirectory;
            }
            else
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            sfd.Filter = filter;
            sfd.Title = title;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                s_recentOpenDirectory = new FileInfo(sfd.FileName).DirectoryName;
                return sfd.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
