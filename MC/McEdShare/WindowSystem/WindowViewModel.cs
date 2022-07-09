// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.WindowSystem
{
    internal abstract class WindowViewModel : ViewModelBase
    {
        private string _title;
        private bool _isMaximize;
        private bool _isTopMost;
        private Uri _imageUri;
        private bool _isDialogMode;

        private float _width;
        private float _height;
        private float _minWidth;
        private float _minHeight;

        private Uri _minimizeImageUri;
        private Uri _maximizeImageUri;
        private Uri _restoreImageUri;
        private Uri _closeImageUri;

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
        public bool IsMaximize
        {
            get => _isMaximize;
            set
            {
                _isMaximize = value;
                NotifyPropertyChanged();
            }
        }
        public Uri ImageUri { get => _imageUri; set { _imageUri = value; NotifyPropertyChanged(); } }
        public bool IsTopMost { get => _isTopMost; set { _isTopMost = value; NotifyPropertyChanged(); } }
        public bool IsDialogMode { get => _isDialogMode; set { _isDialogMode = value; NotifyPropertyChanged(); } }

        public float Width { get => _width; set { _width = value; NotifyPropertyChanged(); } }
        public float Height { get => _height; set { _height = value; NotifyPropertyChanged(); } }
        public float MinWidth { get => _minWidth; set { _minWidth = value; NotifyPropertyChanged(); } }
        public float MinHeight { get => _minHeight; set { _minHeight = value; NotifyPropertyChanged(); } }

        public Uri MinimizeImageUri { get => _minimizeImageUri; set { _minimizeImageUri = value; NotifyPropertyChanged(); } }
        public Uri MaximizeImageUri { get => _maximizeImageUri; set { _maximizeImageUri = value; NotifyPropertyChanged(); } }
        public Uri RestoreImageUri { get => _restoreImageUri; set { _restoreImageUri = value; NotifyPropertyChanged(); } }
        public Uri CloseImageUri { get => _closeImageUri; set { _closeImageUri = value; NotifyPropertyChanged(); } }

        public bool EnableToolBar
        {
            get => _enableToolBar;
            set
            {
                _enableToolBar = value;
                NotifyPropertyChanged();
            }
        }

        public WindowViewModel() : base()
        {
            Title = string.Empty;
            IsTopMost = false;
            IsDialogMode = false;
            Width = MinWidth = 1000;
            Height = MinHeight = 650;
            EnableToolBar = true;
        }
    }
}