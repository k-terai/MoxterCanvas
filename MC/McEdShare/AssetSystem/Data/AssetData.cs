// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using McEdShare.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.AssetSystem
{
    [DataContract]
    [Serialize(SerializeAttribute.SerializeType.Json)]
    public abstract record AssetData : SerializableBase
    {

        /// <summary>
        /// Asset unique id.
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// Asset convert type.
        /// </summary>
        [DataMember]
        public string ConvertType { get; set; }

       
    }
}
