// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.CanvasSystem
{
    public abstract class Image : CanvasElement
    {
#if WPF
        private string _path;
        private double _strokeThickness;

        public string Path { get { return _path; } set { _path = value; NotifyPropertyChanged(); } }
        public double StrokeThickness { get => _strokeThickness; set { _strokeThickness = value; NotifyPropertyChanged(); } }
#endif
    }
}
