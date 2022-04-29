// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.ControlSystem;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.TabSystem
{
    public class TabItemViewModel : ViewModelBase
    {
        private string _header;
        private IControl _contentControl;

        public string Header { get => _header; set { _header = value; NotifyPropertyChanged(); } }
        public IControl ContentControl { get => _contentControl; set { _contentControl = value; NotifyPropertyChanged(); } }
    }
}
