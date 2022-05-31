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
        private Guid _id;

        public string Path { get => _path; }

        public NodeType Type { get => _type; }
        public Guid Id { get => _id;}

        public NodeMenuAttribute(NodeType type,string path,string guid)
        {
            _type = type;
            _path = path;
            _id = Guid.ParseExact(guid,"B"); //B == {00000000-0000-0000-0000-000000000000}
        }
    }
}
