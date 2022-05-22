﻿// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CanvasSystem;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;

namespace McEdShare.NodeSystem
{
    [DataContract]
    public abstract class NodeBase : SerializableBase
    {
        private ObservableCollection<CanvasElement> _elements;

        [DataMember]
        public double X { get; set; }

        [DataMember]
        public double Y { get; set; }

        public ObservableCollection<CanvasElement> Elements { get => _elements; protected set { _elements = value; NotifyPropertyChanged(); } }


        public NodeBase()
        {
            X = 0;
            Y = 0;
            Elements = new ObservableCollection<CanvasElement>();
        }
     
        public void Set(ObservableCollection<CanvasElement> source)
        {
            foreach(var e in _elements)
            {
                source.Add(e);
            }
        }
    }
}