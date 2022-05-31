// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEditor.Controls;
using McEditor.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor
{
    public static class EditorManager
    {
        public static ICanvasControl CreateCanvasControl()
        {
            return new CanvasControl();
        }

        public static ISaveFileDialog CreateSaveFileDialog()
        {
            return new SaveFileDialog();
        }

    }
}
