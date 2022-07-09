// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.CoreSystem
{
    [DataContract]
    internal abstract class SerializableBase
    {
        /// <summary>
        /// Data serialize version.
        /// </summary>
        [DataMember]
        public uint Version { get; set; }
    }
}