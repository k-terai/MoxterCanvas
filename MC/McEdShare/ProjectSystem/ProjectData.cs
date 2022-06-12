﻿// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.ProjectSystem
{
    [DataContract]
    [Serialization.Serialize(Serialization.SerializeAttribute.SerializeType.Json)]
    public sealed record ProjectData : SerializableBase
    {
        /// <summary>
        /// Project unique id.
        /// </summary>
        [DataMember]
        public Guid Id { get; set; }

        public ProjectData() : base()
        {
            Version = 1;
        }

    }
}
