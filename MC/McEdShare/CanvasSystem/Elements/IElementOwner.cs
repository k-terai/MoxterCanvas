// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.CanvasSystem.Elements
{
    public interface IElementOwner
    {
        public void Translate(double x, double y, EditorCommon.Space space);
    }
}
