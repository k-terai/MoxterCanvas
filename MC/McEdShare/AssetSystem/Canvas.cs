// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.AssetSystem
{
    public sealed class Canvas : Asset
    {
        private CanvasData _canvasData;

        protected override AssetData Data => _canvasData;

        public override bool Initialize(AssetContext context)
        {
            Name = context.Name;
            Directory = context.Directory;
            Extension = context.Extension;

            if (context.IsDataExists)
            {
                _canvasData = Serializer.Deserialize<CanvasData>(FullPath);
                IsDirty = false;
            }
            else
            {
                _canvasData = new CanvasData()
                {
                    Id = Guid.NewGuid(),
                    Version = 1,
                    ConvertType = "None"
                };
                IsDirty = true;
            }

            return _canvasData != null;
        }

        public override bool Save()
        {
            var isSuccess = Serializer.Serialize(_canvasData, FullPath);
            IsDirty = !isSuccess;

            return isSuccess;
        }
    }
}
