// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.NodeSystem
{
    public class NodeMenuAttribute : Attribute
    {
        [System.Flags]
        public enum NodeType
        {
            None = 0x01 << 1,
            Unique = 0x01 << 2
        }


        private string _path;
        private NodeType _type;

        public string Path { get => _path; }

        public NodeType Type { get => _type; }

        public NodeMenuAttribute(NodeType type,string path)
        {
            _type = type;
            _path = path;
        }
    }
}
