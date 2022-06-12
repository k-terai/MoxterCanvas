// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CanvasSystem;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static McEdShare.CoreSystem.EditorCommon;

namespace McEdShare.NodeSystem
{
    public class NodeController
    {
        private ObservableCollection<NodeBase> _nodes = new ObservableCollection<NodeBase>();

        public T CreateNode<T>() where T : NodeBase, new()
        {
            var node = new T();
            _nodes.Add(node);
            return node;
        }

        public NodeBase CreateNode(string fullName)
        {
            var node = AssemblyUtility.CreateInstance<NodeBase>(fullName);
            _nodes.Add(node);
            return node;
        }

        public bool IsNodeExists(Guid id)
        {
            return _nodes.Count(n => n.Id.Equals(id)) != 0;
        }

        public void TranslateNodes(double x, double y, Space space)
        {
            foreach (var n in _nodes)
            {
                n.Translate(x, y, space);
            }
        }
    }
}
