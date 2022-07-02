// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace McEdShare.AssetSystem
{
    public class NormalFolder : Asset
    {
        private ObservableCollection<Asset> _childs;

        public ObservableCollection<Asset> Childs { get => _childs; protected set { _childs = value; NotifyPropertyChanged(); } }
        public NormalFolder ParentFolder { get => Parent as NormalFolder; }

        public NormalFolder() : base()
        {
            Childs = new ObservableCollection<Asset>();
        }

        public override void Initialize(AssetContext context)
        {
            base.Initialize(context);

            OnChildAssetInitialized += (Asset ca) =>
            {
                Childs.Add(ca);
            };
        }

        public NormalFolder CreateFolder(string name)
        {
            try
            {
                var d = Directory.CreateDirectory(Path.Combine(FullPath, name));
                var f = new NormalFolder();
                f.Initialize(new AssetContext(d, this));
                return f;
            }
            catch (IOException exception)
            {
                return null;
            }
        }

        public DirectoryInfo GetDirectoryInfo()
        {
            return new DirectoryInfo(FullPath);
        }

        public override bool Rename(string name)
        {
            try
            {
                var newName = name;
                var newDirectoryPath = Path.Combine(Parent.FullPath, newName + Extension);
                var newMetaPath = Path.Combine(Parent.FullPath, newName + Extension + EditorConsts.ASSET_METADATA_EXTENSION);

                Directory.Move(FullPath, newDirectoryPath);
                File.Move(MetaDataFullPath, newMetaPath);

                Name = name;
                return true;

            }
            catch (IOException exception)
            {
                return false;
            }
        }
    }
}
