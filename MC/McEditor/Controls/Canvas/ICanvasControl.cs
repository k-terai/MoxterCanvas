// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.ControlSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Controls
{
    public interface ICanvasControl : IEditAssetControl
    {
        CanvasControlViewModel ViewModel { get; }
    }
}
