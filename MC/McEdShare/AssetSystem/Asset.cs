// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.AssetSystem
{
    public abstract class Asset : NotifyPropertyChangedBase
    {
        private string _name;
        private string _fullPath;

        protected abstract AssetData Data { get; }

        public string Name { get => _name; protected set { _name = value; NotifyPropertyChanged(); } }

        public string FullPath { get => _fullPath; protected set { _fullPath = value; NotifyPropertyChanged(); } }

        public Guid Id { get => Data.Id; }


        public abstract bool Initialize(AssetContext context);

        public abstract bool Save();

        public void SetFullPath(string fullPath)
        {
            FullPath = fullPath;
        }

        public void Rename(string newName)
        {
            Name = newName;
        }
    }
}
