// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace McEdShare.CanvasSystem
{
    public class CanvasContextMenu : NotifyPropertyChangedBase
    {
        private string _name;
        private ObservableCollection<CanvasContextMenu> _children;
        private DelegateCommand _command;
        private bool _isEnabled;
        private bool _isSeparator;

        public string Name { get => _name; set { _name = value; NotifyPropertyChanged(); } }
        public ObservableCollection<CanvasContextMenu> Children { get => _children; set { _children = value; NotifyPropertyChanged(); } }

        public DelegateCommand Command { get => _command; set { _command = value; NotifyPropertyChanged(); } }

        public bool IsEnabled { get => _isEnabled; set { _isEnabled = value; NotifyPropertyChanged(); } }

        public bool IsSeparator { get => _isSeparator; set { _isSeparator = value; NotifyPropertyChanged(); } }

        public CanvasContextMenu(string name, bool isSeparator = false)
        {
            Name = name;
            IsEnabled = true;
            Children = new ObservableCollection<CanvasContextMenu>();
            IsSeparator = isSeparator;
        }
    }
}
