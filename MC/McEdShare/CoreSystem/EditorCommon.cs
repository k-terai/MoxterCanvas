// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;


#if WPF
using System.Windows.Media;
#endif

namespace McEdShare.CoreSystem
{
    public static class EditorCommon
    {
        public enum ElementTemplate
        {
            Function
        }

        public static readonly Brush s_NodeBackgroundBrush = new SolidColorBrush(Color.FromRgb(40,40,40));
        public static readonly Brush s_NodeHeaderBrush = new SolidColorBrush(Color.FromRgb(50, 50, 50));
        public static readonly Brush s_NodeForegroundBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
    }
}
