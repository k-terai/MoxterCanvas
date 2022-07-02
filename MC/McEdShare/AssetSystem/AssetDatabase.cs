// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.TreeSystem.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace McEdShare.AssetSystem
{
    internal static class AssetDatabase
    {
        private static Dictionary<string, Uri> s_assetIconUriCache = new Dictionary<string, Uri>();
        private static Dictionary<Guid, Asset> s_projectAssets;

        public static RootFolder Root { get; private set; }

        public static bool Startup()
        {
            s_projectAssets = new Dictionary<Guid, Asset>();
            Asset.OnBaseAssetInitialized += OnBaseAssetInitialized;
            return true;
        }

        public static bool Initialize()
        {
            InitializeProjectAssets();
            return true;
        }

        public static void RegisterIconUrl<T>(Uri uri)
            where T : Asset
        {
            var name = typeof(T).Name;
            s_assetIconUriCache[name] = uri;
        }

        public static Uri GetIconUri<T>()
            where T : Asset
        {
            return s_assetIconUriCache[typeof(T).Name];
        }

        public static T GetAssetFromFullPath<T>(string fullPath)
           where T : Asset
        {
            var a = s_projectAssets.Values.FirstOrDefault(t => t.FullPath.Equals(fullPath));
            return a as T;
        }

        /// <summary>
        /// Create <see cref="AssetTreeComponent"/> basis on <see cref="RootFolder"/>
        /// </summary>
        /// <returns>New <see cref="AssetTreeComponent"/> instance.</returns>
        public static AssetTreeComponent CreateNewRootTree()
        {
            var root = AssetTreeComponent.CreateNewRootTree(Root, Root.Name);
            InitAssetTreeFromAssetsFolderRecursive(Root, root);
            return root;
        }

        private static void RegisterAsset(Asset asset)
        {
            Debug.Assert(s_projectAssets.ContainsKey(asset.Id) == false);
            s_projectAssets[asset.Id] = asset;
        }

        private static void InitializeProjectAssets()
        {
            Root = RootFolder.CreateInstance();
            InitializeProjectAssetsRecursive(Root);
        }

        private static void InitializeProjectAssetsRecursive(NormalFolder folder)
        {
            var d = folder.GetDirectoryInfo();
            var cds = d.GetDirectories("*", System.IO.SearchOption.TopDirectoryOnly);
            var cfs = d.GetFiles("*", System.IO.SearchOption.TopDirectoryOnly);


            foreach (var file in cfs)
            {

            }

            foreach (var directory in cds)
            {
                var f = new NormalFolder();
                f.Initialize(new AssetContext(directory, folder));
                InitializeProjectAssetsRecursive(f);
            }
        }

        private static void InitAssetTreeFromAssetsFolderRecursive(NormalFolder folder, AssetTreeComponent tree)
        {
            if (folder.Childs == null)
            {
                return;
            }

            foreach (var c in folder.Childs)
            {
                var nt = tree.AddChild(c, c.Name);
                if (c is NormalFolder normalFolder)
                {
                    InitAssetTreeFromAssetsFolderRecursive(normalFolder, nt);
                }
            }
        }

        private static void OnBaseAssetInitialized(Asset obj)
        {
            RegisterAsset(obj);
        }

    }
}
