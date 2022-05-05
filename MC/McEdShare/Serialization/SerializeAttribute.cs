// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.Serialization
{
    [AttributeUsage(AttributeTargets.Class)]
    public class SerializeAttribute : Attribute
    {
        public enum SerializeType
        {
            Json
        }

        public SerializeType Type { get; private set; }

        public SerializeAttribute(SerializeType type)
        {
            Type = type;
        }
    }
}
