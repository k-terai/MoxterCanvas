// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.AssetSystem
{
    [DataContract]
    [Serialization.Serialize(Serialization.SerializeAttribute.SerializeType.Json)]
    public sealed class AssetMetaData : SerializableBase
    {
        /// <summary>
        /// Asset unique id.
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Asset convert type.(Ex. texture id .dds format)
        /// </summary>
        [DataMember]
        public string ConvertType { get; set; }

        public AssetMetaData()
        {
            Version = 1;
        }

    }
}
