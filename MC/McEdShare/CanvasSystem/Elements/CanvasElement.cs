// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CanvasSystem.Elements;
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
        private IElementOwner _owner;

        private double _worldX;
        private double _worldY;
        private double _localX;
        private double _localY;
        private double _offsetX;
        private double _offsetY;
        private double _width;
        private double _height;

        public IElementOwner Owner { get => _owner; set { _owner = value; NotifyPropertyChanged(); } }

        public double WorldX { get => _worldX; set { _worldX = value; NotifyPropertyChanged(); NotifyPropertyChanged("X"); } }

        public double WorldY { get => _worldY; set { _worldY = value; NotifyPropertyChanged(); NotifyPropertyChanged("Y"); } }

        public double LocalX { get => _localX; set { _localX = value; NotifyPropertyChanged(); NotifyPropertyChanged("X"); } }

        public double LocalY { get => _localY; set { _localY = value; NotifyPropertyChanged(); NotifyPropertyChanged("Y"); } }

        public double OffsetX { get => _offsetX; set { _offsetX = value; NotifyPropertyChanged(); NotifyPropertyChanged("X"); } }

        public double OffsetY { get => _offsetY; set { _offsetY = value; NotifyPropertyChanged(); NotifyPropertyChanged("Y"); } }

        public double X { get { return WorldX + LocalX + OffsetX; } }

        public double Y { get { return WorldY + LocalY + OffsetY; } }

        public double Width { get => _width; set { _width = value; NotifyPropertyChanged(); } }

        public double Height { get => _height; set { _height = value; NotifyPropertyChanged(); } }


    }


}
