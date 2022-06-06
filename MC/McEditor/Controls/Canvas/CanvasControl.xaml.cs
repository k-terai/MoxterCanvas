// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.AssetSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace McEditor.Controls
{
    /// <summary>
    /// CanvasControl.xaml の相互作用ロジック
    /// </summary>
    public partial class CanvasControl : UserControl, ICanvasControl
    {
        public UserControl Control => this;

        public CanvasControlViewModel ViewModel => DataContext as CanvasControlViewModel;

        public Asset Target => ViewModel.TargetCanvas;

        private Point _previousMousePoint = new Point();

        public CanvasControl()
        {
            InitializeComponent();
        }

        private void MainCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ViewModel.IsMouseDragMode = true;
        }

        private void MainCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ViewModel.IsMouseDragMode = false;
            _previousMousePoint = new Point();
        }

        private void MainCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (ViewModel.IsMouseDragMode)
            {
                var pos = e.GetPosition(this);
                double diffX = 0;
                double diffY = 0;

                // First mouse drag is too moving,so we prevent this.
                if (_previousMousePoint.X != 0 || _previousMousePoint.Y != 0)
                {
                    diffX = pos.X - _previousMousePoint.X;
                    diffY = pos.Y - _previousMousePoint.Y;
                }

                ViewModel.Controller.SetCanvasOffset(diffX, diffY);
                _previousMousePoint = pos;
            }
        }


    }
}
