// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.CoreSystem
{
    public static class EditorConsts
    {
        // Projects.
        public const string PROJECT_DATA_EXTENSION = ".project";
        public const string ASSETS_DIRECTORY_NAME = "Assets";
        public const string RUNTIME_DIRECTORY_NAME = "Runtime";
        public const string PLUGIN_DIRECTORY_NAME = "Plugins";
        public const string PROJECTSETTINGS_DIRECTORY_NAME = "ProjectSettings";
        public const string USERSETTINGS_DIRECTORY_NAME = "UserSettings";
        public const int MAX_PROJECTNAME_LENGTH = 20;

        //Assets.
        public const string ASSET_METADATA_EXTENSION = ".meta";
        public const int MAX_ASSET_NAME_LENGTH = 50;

        // Thumbnail sizes.
        public const int TINY_THUMBNAIL_SIZE = 40;
        public const int SMALL_THUMBNAIL_SIZE = 80;
        public const int MEDIUM_THUMBNAIL_SIZE = 150;
        public const int LARGE_THUMBNAIL_SIZE = 200;
        public const int HUGE_THUMBNAIL_SIZE = 300;
    }
}
