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
        private double _localX;
        private double _localY;
        private double _offsetX;
        private double _offsetY;
        private double _x;
        private double _y;
        private double _width;
        private double _height;

        public double LocalX { get => _localX; set { _localX = value; NotifyPropertyChanged(); } }

        public double LocalY { get => _localY; set { _localY = value; NotifyPropertyChanged(); } }

        public double OffsetX { get => _offsetX; set { _offsetX = value; NotifyPropertyChanged();NotifyPropertyChanged("X"); } }

        public double OffsetY { get => _offsetY; set { _offsetY = value; NotifyPropertyChanged(); NotifyPropertyChanged("Y"); } }

        public double X { get { return _x + LocalX + OffsetX; } set { _x = value; NotifyPropertyChanged(); } }

        public double Y { get { return _y + LocalY + OffsetY; } set { _y = value; NotifyPropertyChanged(); } }

        public double Width { get => _width; set { _width = value; NotifyPropertyChanged(); } }

        public double Height { get => _height; set { _height = value; NotifyPropertyChanged(); } }


    }


}
