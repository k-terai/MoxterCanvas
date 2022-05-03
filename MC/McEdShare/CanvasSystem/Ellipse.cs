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
    public sealed class Ellipse : CanvasElement
    {
#if WPF
        private Brush _fill;
        private Brush _stroke;
        private double _strokeThickness;

        public Brush Fill { get => _fill; set { _fill = value; NotifyPropertyChanged(); } }

        public Brush Stroke { get => _stroke; set { _stroke = value; NotifyPropertyChanged(); } }

        public double StrokeThickness { get => _strokeThickness; set { _strokeThickness = value; NotifyPropertyChanged(); } }
#endif

    }
}
