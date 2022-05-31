// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.AssetSystem
{
    public abstract class Asset : NotifyPropertyChangedBase
    {
        private string _name;
        private string _extension;
        private bool _isDirty;
        private DirectoryInfo _directory;

        protected abstract AssetData Data { get; }

        public string Name
        {
            get => _name;
            protected set
            {
                _name = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("DisplayName");
            }
        }

        public string DisplayName
        {
            get
            {
                return IsDirty ? Name + "*" : Name;
            }
        }

        public string Extension { get => _extension; protected set { _extension = value; NotifyPropertyChanged(); } }

        public DirectoryInfo Directory { get => _directory; protected set { _directory = value; NotifyPropertyChanged(); } }

        public string FullPath { get => Path.Combine(Directory.FullName, Name + Extension); }


        public Guid Id { get => Data.Id; }

        public bool IsDirty
        {
            get => _isDirty; set
            {
                _isDirty = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("DisplayName");
            }
        }

        public abstract bool Initialize(AssetContext context);

        public abstract bool Save();

        public void SetDirectory(DirectoryInfo directory)
        {
            Directory = directory;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
