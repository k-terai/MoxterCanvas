// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CanvasSystem;
using McEdShare.CanvasSystem.Elements;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.NodeSystem
{
    [DataContract]
    public abstract record NodeBase : SerializableBase, IElementOwner
    {
        private ObservableCollection<CanvasElement> _elements;
        private Guid _id;

        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }

        [IgnoreDataMember]
        public ObservableCollection<CanvasElement> Elements { get => _elements; protected set { _elements = value;  } }

        [IgnoreDataMember]
        public Guid Id { get => _id; }

        public NodeBase()
        {
            var attribute = GetType().GetCustomAttributes(typeof(NodeMenuAttribute), true)[0] as NodeMenuAttribute;
            Debug.Assert(attribute != null);

            _id = attribute.Id;
            X = 0;
            Y = 0;
            Elements = new ObservableCollection<CanvasElement>();
        }

        public void Set(ObservableCollection<CanvasElement> source)
        {
            if (source == null)
            {
                return;
            }

            foreach (var e in _elements)
            {
                source.Add(e);
            }
        }

        public void Translate(double x, double y, EditorCommon.Space space)
        {
            switch (space)
            {
                case EditorCommon.Space.Canvas:
                    foreach (var e in Elements)
                    {
                        e.OffsetX += x;
                        e.OffsetY += y;
                    }
                    break;

                case EditorCommon.Space.World:
                    {
                        foreach (var e in Elements)
                        {
                            e.WorldX += x;
                            e.WorldY += y;
                        }
                    }
                    break;
                case EditorCommon.Space.Local:
                    {
                        foreach (var e in Elements)
                        {
                            e.LocalX += x;
                            e.LocalY += y;
                        }
                    }
                    break;
            }
        }

        protected void SetOwner()
        {
            foreach (var e in Elements)
            {
                e.Owner = this;
            }
        }
    }
}