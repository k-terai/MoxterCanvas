// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.AssetSystem
{
    public static class AssetDatabase
    {
        public static T CreateAsset<T>(AssetContext context)
            where T : Asset, new()
        {
            var asset = new T();
            var isInitializeComplete = asset.Initialize(context);

            return isInitializeComplete ? asset : null;
        }
    }
}
