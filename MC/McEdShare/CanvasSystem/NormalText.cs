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
    public class NormalText : CanvasElement
    {
#if WPF
        private string _text;
        private Brush _foreground;
        private Brush _background;
        private bool _isReadOnly;

        public string Text { get => _text; set { _text = value; NotifyPropertyChanged(); } }

        public Brush Foreground { get => _foreground; set { _foreground = value; NotifyPropertyChanged(); } }

        public Brush Background { get => _background; set { _background = value; NotifyPropertyChanged(); } }

        public bool IsReadOnly { get => _isReadOnly; set { _isReadOnly = value; NotifyPropertyChanged(); } }
#endif


    }
}
