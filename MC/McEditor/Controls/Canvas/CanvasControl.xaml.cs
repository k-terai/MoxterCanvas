﻿// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.


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

        public CanvasControl()
        {
            InitializeComponent();
        }

    }
}
