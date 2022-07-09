﻿using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.CoreSystem
{
    internal static class EditorCommon
    {
        /// <summary>
        /// Define all editor results that should be check.
        /// This enum is only define editor results such as folder path missing,not include runtime.
        /// </summary>
        public enum Result
        {
            OK = 0,                  // Success
            ERROR_PROJECTNAME_MIN,   // Project name error.A character has not been entered.
            ERROR_PROJECTNAME_MAX,   // Project name error.name is too long.
            ERROR_PROJECTNAME_INVALID,    // Project name error.Invalid character in project name.
            ERROR_PROJECTNAME_DOUBLEBYTE, // Project name error.Contains double-byte characters.
            ERROR_PROJECTNAME_PATH_EXISTS, // Path error.A folder with that name already exists at that location.
            ERROR_PROJECTPATH_NOT_EXISTS,   // Location error.A folder with that name not exists.
            ERROR_ASSETNAME_MIN, // Asset name error.A character has not been entered.
            ERROR_ASSETNAME_MAX, // Asset name error.name is too long.
            ERROR_ASSETNAME_INVALID, // Asset name error.Invalid character in asset name.
            ERROR_ASSETNAME_DOUBLEBYTE, // Asset name error. Contains double-byte characters.
            ERROR_ASSETNAME_SAMENAME    // Asset name error. Same name asset already exists.
        }
    }
}
