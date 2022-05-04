// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;


#if WPF
using System.Windows.Media;
#endif


namespace McEdShare.CanvasSystem
{
    public sealed class Path : CanvasElement
    {
#if WPF
        private Brush _stroke;
        private string _data;
        private double _strokeThickness;

        public Brush Stroke { get => _stroke; set { _stroke = value; NotifyPropertyChanged(); } }
        public string Data { get => _data; set { _data = value; NotifyPropertyChanged(); } }

        public double StrokeThickness { get => _strokeThickness; set { _strokeThickness = value; NotifyPropertyChanged(); } }

#endif

    }
}
