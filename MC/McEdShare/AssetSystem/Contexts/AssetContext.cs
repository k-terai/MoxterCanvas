// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace McEdShare.AssetSystem
{
    public class AssetContext
    {
        public string Name { get; private set; }
        public string FullPath { get; private set; }
        public string Extension { get; private set; }

        public bool IsDataExists { get; private set; }

        public Uri DefaultUri { get; set; }

        public AssetContext(string fullPath)
        {
            Name = Path.GetFileNameWithoutExtension(fullPath);
            FullPath = fullPath;
            Extension = Path.GetExtension(fullPath);
            IsDataExists = File.Exists(fullPath);
        }

    }
}
