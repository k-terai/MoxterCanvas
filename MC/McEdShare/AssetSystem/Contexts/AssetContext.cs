// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace McEdShare.AssetSystem
{
    public class AssetContext
    {
        public Asset Parent { get; private set; }
        public string Name { get; private set; }
        public string FullPath { get; private set; }
        public string Extension { get; private set; }
        public string ConvertType { get; private set; }
        public bool IsMetaDataExists { get; set; } = false;
        public Uri DefaultUri { get; set; }

        public AssetContext(string fullpath, Asset parent)
        {
            Parent = parent;

            if (Directory.Exists(fullpath))
            {
                Initialize(new DirectoryInfo(fullpath), parent);
            }
            else if (File.Exists(fullpath))
            {

            }

            IsMetaDataExists = File.Exists(FullPath + EditorConsts.ASSET_METADATA_EXTENSION);
        }

        public AssetContext(DirectoryInfo info, Asset parent)
        {
            Initialize(info, parent);
        }

        private void Initialize(DirectoryInfo info, Asset parent)
        {
            Parent = parent;
            Name = info.Name;
            FullPath = info.FullName;
            Extension = string.Empty;
            ConvertType = string.Empty;
        }
    }
}
