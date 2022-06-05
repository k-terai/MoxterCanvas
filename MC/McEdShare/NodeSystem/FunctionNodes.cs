// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CanvasSystem;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using static McEdShare.NodeSystem.NodeMenuAttribute;

#if WPF
using System.Windows.Media;
#endif

namespace McEdShare.NodeSystem
{
    [DataContract]
    [NodeMenu(NodeType.Unique, "Funtion/Start", "{C6FC1F94-D68B-47D2-B3DB-7BDD3058A8E5}")]
    public sealed class StartNode : NodeBase
    {
        public StartNode() : base()
        {
            var rectangle = new Rectangle();
            rectangle.X = 0;
            rectangle.Y = 0;
            rectangle.Width = 150;
            rectangle.Height = 100;
            rectangle.Fill = EditorCommon.s_NodeBackgroundBrush;
            rectangle.StrokeThickness = 1;
            rectangle.Stroke = EditorCommon.s_NodeHeaderBrush;

            var header = new Rectangle();
            header.X = 0;
            header.Y = 0;
            header.Width = 150;
            header.Height = 25;
            header.Fill = EditorCommon.s_NodeHeaderBrush;
            header.StrokeThickness = 1;
            header.Stroke = EditorCommon.s_NodeHeaderBrush;

            var text = new NormalText();
            text.LocalX = 150 / 2 - 25;
            text.Text = "Start";
            text.Width = 150;
            text.Height = 25;
            text.Foreground = EditorCommon.s_NodeForegroundBrush;
            text.FontSize = 18;

            Elements.Add(rectangle);
            Elements.Add(header);
            Elements.Add(text);

        }
    }
}
