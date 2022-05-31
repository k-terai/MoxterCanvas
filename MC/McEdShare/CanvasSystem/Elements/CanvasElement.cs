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
    public abstract class CanvasElement : NotifyPropertyChangedBase
    {
        private double _x;
        private double _y;
        private double _width;
        private double _height;

        public double X { get => _x; set { _x = value; NotifyPropertyChanged(); } }

        public double Y { get => _y; set { _y = value; NotifyPropertyChanged(); } }

        public double Width { get => _width; set { _width = value; NotifyPropertyChanged(); } }

        public double Height { get => _height; set { _height = value; NotifyPropertyChanged(); } }

    }

   
}
