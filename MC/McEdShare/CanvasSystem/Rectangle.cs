// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

#if WPF
using System.Windows.Media;
#endif

namespace McEdShare.CanvasSystem
{
    public sealed class Rectangle : CanvasElement
    {
#if WPF
        private Brush _fill;

        public Brush Fill { get => _fill; set { _fill = value; NotifyPropertyChanged(); } }
#endif

    }
}
