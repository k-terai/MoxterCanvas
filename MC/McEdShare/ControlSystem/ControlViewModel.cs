// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.ControlSystem
{
    public class ControlViewModel : ViewModelBase
    {
        private string _title;
        private bool _enableToolBar;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                NotifyPropertyChanged();
            }
        }

        public bool EnableToolBar
        {
            get => _enableToolBar;
            set
            {
                _enableToolBar = value;
                NotifyPropertyChanged();
            }
        }

        public ControlViewModel() : base()
        {
            Title = string.Empty;
            EnableToolBar = true;
        }
    }
}
