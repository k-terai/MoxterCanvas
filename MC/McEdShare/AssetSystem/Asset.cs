// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using McEdShare.LocalizationSystem;
using McEdShare.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using static McEdShare.CoreSystem.EditorCommon;

namespace McEdShare.AssetSystem
{
    public abstract class Asset : NotifyPropertyChangedBase
    {
        /// <summary>
        /// NOTE: null is possible.(Ex: Root folder)
        /// </summary>
        private Asset _parent;
        private string _name;
        private AssetMetaData _metaData;
        private Uri _defaultUri;
        private bool _isDirty;

        protected event Action<Asset> OnChildAssetInitialized;
        protected AssetMetaData MetaData { get => _metaData; set => _metaData = value; }

        public static event Action<Asset> OnBaseAssetInitialized;

        public Asset Parent { get => _parent; protected set { _parent = value; NotifyPropertyChanged(); } }
        public string Name { get => _name; protected set { _name = value; NotifyPropertyChanged(); } }
        public Uri DefaultUri { get => _defaultUri; protected set { _defaultUri = value; NotifyPropertyChanged(); } }
        public string Extension { get; protected set; }
        public string NameWithExtension { get => Name + Extension; }
        public Guid Id { get => _metaData.Id; }
        public string ConvertType { get => _metaData.ConvertType; }
        public uint Version { get => _metaData.Version; }

        /// <summary>
        /// Absolute path (Ex. C:...)
        /// </summary>
        public virtual string FullPath { get => Path.Combine(_parent.FullPath, NameWithExtension); }

        /// <summary>
        /// Relative path from project folder.(Ex. Assets/Textures/SampleTexture.png)
        /// </summary>
        public virtual string RelativePath
        {
            get => Path.Combine(_parent.RelativePath, NameWithExtension);
        }

        public string MetaDataFullPath { get => FullPath + EditorConsts.ASSET_METADATA_EXTENSION; }

        public bool IsDirty { get => _isDirty; set { _isDirty = value; NotifyPropertyChanged(); } }

        public virtual void Initialize(AssetContext context)
        {
            Parent = context.Parent;
            Name = context.Name;
            DefaultUri = context.DefaultUri;

            if (!context.IsMetaDataExists)
            {
                CreateMetaData(context);
            }
            else
            {
                MetaData = Serializer.Deserialize<AssetMetaData>(MetaDataFullPath);
            }

            if (Parent != null)
            {
                Parent.OnChildAssetInitialized?.Invoke(this);
            }

            IsDirty = false;
            OnBaseAssetInitialized?.Invoke(this);
        }

        public virtual bool Save()
        {
            if (IsDirty)
            {
                IsDirty = false;
                return Serializer.Serialize(_metaData, MetaDataFullPath);
            }

            return true;
        }

        public virtual bool Rename(string name)
        {
            try
            {
                var newName = name;
                var newFilePath = Path.Combine(Parent.FullPath, newName + Extension);
                var newMetaPath = Path.Combine(Parent.FullPath, newName + Extension + EditorConsts.ASSET_METADATA_EXTENSION);

                File.Move(FullPath, newFilePath);
                File.Move(MetaDataFullPath, newMetaPath);

                Name = name;
                return true;

            }
            catch (IOException exception)
            {
                return false;
            }
        }

        public static Result IsValidName(string name, NormalFolder parent)
        {
            var c = name;

            //Check min length.
            if (c == null || c.Length == 0)
            {
                return Result.ERROR_PROJECTNAME_MIN;
            }

            //Check max length.
            if (c.Length > EditorConsts.MAX_ASSET_NAME_LENGTH)
            {
                return Result.ERROR_ASSETNAME_MAX;
            }

            //Check characters.
            char[] invalidChars = Path.GetInvalidFileNameChars();
            char[] invalidPathChars = Path.GetInvalidPathChars();

            if (c.IndexOfAny(invalidChars) > 0 || c.IndexOfAny(invalidPathChars) > 0 || c.Contains(" ") || c.Contains("　"))
            {
                return Result.ERROR_ASSETNAME_INVALID;
            }

            //Check Half-width character.
            if (LocalizationManager.Shift_JIS_Encoding.GetByteCount(c) != c.Length)
            {
                return Result.ERROR_ASSETNAME_DOUBLEBYTE;
            }

            //Check if there is a asset with the same name.
            if (parent.Childs.Count(t => t.Name == c) != 0)
            {
                return Result.ERROR_ASSETNAME_SAMENAME;
            }

            return Result.OK;
        }

        protected virtual bool CreateMetaData(AssetContext context)
        {
            _metaData = new AssetMetaData()
            {
                Version = 1,
                ConvertType = context.ConvertType,
                Id = Guid.NewGuid()
            };

            return Serializer.Serialize(_metaData, MetaDataFullPath);
        }
    }
}
