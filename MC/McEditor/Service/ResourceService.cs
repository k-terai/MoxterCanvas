// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Service
{
    public class ResourceService : NotifyPropertyChangedBase
    {
        public const string JAPANACECODE = "ja-jp";
        public const string ENGLISHCODE = "en-us";

        private static readonly ResourceService _current = new ResourceService();

        private readonly Resources _resources = new Resources();

        public static ResourceService Current
        {
            get => _current;
        }

        public Resources Resources
        {
            get { return _resources; }
        }

        public void ChangeCulture(string name)
        {
            Resources.Culture = CultureInfo.GetCultureInfo(name);
            NotifyPropertyChanged("Resources");
        }
    }
}
