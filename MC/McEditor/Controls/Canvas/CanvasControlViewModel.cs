// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.ControlSystem;
using McEdShare.CanvasSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using McEdShare.CoreSystem;
using System.Numerics;
using McEdShare.AssetSystem;
using McEdShare.NodeSystem;
using System.Reflection;

namespace McEditor.Controls
{
    public class CanvasControlViewModel : ControlViewModel
    {
        public enum MouseDragMode
        {
            None,
            Canvas,
            Element
        }

        private ObservableCollection<CanvasElement> _elements;
        private ObservableCollection<CanvasContextMenu> _contextMenus;
        private Canvas _targetCanvas;
        private NodeController _controller;

        private MouseDragMode _dragMode;

        public ObservableCollection<CanvasElement> Elements { get => _elements; set { _elements = value; NotifyPropertyChanged(); } }

        public DelegateCommand TestCommand { get; set; }
        public Canvas TargetCanvas { get => _targetCanvas; set { _targetCanvas = value; NotifyPropertyChanged(); } }

        public ObservableCollection<CanvasContextMenu> ContextMenus { get => _contextMenus; set { _contextMenus = value; NotifyPropertyChanged(); } }

        public MouseDragMode DragMode { get => _dragMode; set { _dragMode = value; NotifyPropertyChanged(); } }

        public NodeController Controller { get => _controller; set { _controller = value; NotifyPropertyChanged(); } }



        public CanvasControlViewModel() : base()
        {
            Controller = new NodeController();
            Elements = new ObservableCollection<CanvasElement>();
            ContextMenus = new ObservableCollection<CanvasContextMenu>();

            InitCommands();
            InitContextMenus();
        }

        private void InitCommands()
        {
            TestCommand = new DelegateCommand((object p) =>
            {
                var t = new StartNode();
                t.Set(Elements);

                //Elements.Clear();
                //var r = new Random();
                //var vectors = new List<Vector2>();

                //bool isRectangle = true;
                //int count = 500;

                //for (int i = 0; i < count; i++)
                //{
                //    var x = r.Next(0, 1500);
                //    var y = r.Next(0, 1500);
                //    vectors.Add(new Vector2(x + 25, y + 25));

                //    if (isRectangle)
                //    {
                //        var rec = new Rectangle()
                //        {
                //            Width = 50,
                //            Height = 50,
                //            X = x,
                //            Y = y,
                //            Fill = new SolidColorBrush(new Color()
                //            {
                //                A = 0,
                //                R = (byte)r.Next(0, 255),
                //                G = (byte)r.Next(0, 255),
                //                B = (byte)r.Next(0, 255),
                //            }),
                //            Stroke = new SolidColorBrush(new Color()
                //            {
                //                A = 255 / 2,
                //                R = (byte)r.Next(0, 255),
                //                G = (byte)r.Next(0, 255),
                //                B = (byte)r.Next(0, 255),
                //            }),
                //            StrokeThickness = 2
                //        };
                //        Elements.Add(rec);
                //    }
                //    else
                //    {
                //        var ellipse = new Ellipse()
                //        {
                //            Width = 50,
                //            Height = 50,
                //            X = x,
                //            Y = y,
                //            Fill = new SolidColorBrush(new Color()
                //            {
                //                A = 0,
                //                R = (byte)r.Next(0, 255),
                //                G = (byte)r.Next(0, 255),
                //                B = (byte)r.Next(0, 255),
                //            }),
                //            Stroke = new SolidColorBrush(new Color()
                //            {
                //                A = 255 / 2,
                //                R = (byte)r.Next(0, 255),
                //                G = (byte)r.Next(0, 255),
                //                B = (byte)r.Next(0, 255),
                //            }),
                //            StrokeThickness = 2
                //        };

                //        Elements.Add(ellipse);
                //    }

                //    isRectangle = !isRectangle;
                //}

                //for (int i = 0; i < count; i += 2)
                //{
                //    var cx = vectors[i].X + 100;
                //    var cy = vectors[i].Y + 100;
                //    var cx1 = vectors[i + 1].X - 100;
                //    var cy1 = vectors[i + 1].Y - 100;


                //    var data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", vectors[i].X, vectors[i].Y, cx, cy, cx1, cy1, vectors[i + 1].X, vectors[i + 1].Y);
                //    var path = new Path()
                //    {
                //        Width = 10000,
                //        Height = 10000,
                //        X = r.Next(0, 0),
                //        Y = r.Next(0, 0),
                //        Data = data,
                //        Stroke = new SolidColorBrush(new Color()
                //        {
                //            A = 255 / 2,
                //            R = (byte)r.Next(0, 255),
                //            G = (byte)r.Next(0, 255),
                //            B = (byte)r.Next(0, 255),
                //        }),
                //        StrokeThickness = 2
                //    };

                //    Elements.Add(path);
                //}

                //{
                //    var text = new NormalText();
                //    text.Width = 100;
                //    text.Height = 200;
                //    text.Text = "Update";
                //    text.Foreground = new SolidColorBrush(Colors.Blue);
                //    text.Background = new SolidColorBrush(Colors.Transparent);
                //    text.IsReadOnly = true;
                //    Elements.Add(text);
                //}
            });
        }

        private void InitContextMenus()
        {
            foreach (var nodeClass in AssemblyUtility.GetTypesFromAssemblyMatchAttribute<NodeMenuAttribute>())
            {
                var attri = nodeClass.GetCustomAttribute<NodeMenuAttribute>();
                var pathes = attri?.Path?.Split("/");
                string parent = string.Empty;

                var length = pathes.Length;

                for (int i = 0; i < length; i++)
                {
                    var context = new CanvasContextMenu(pathes[i]);

                    if (i + 1 == length)
                    {
                        context.Command = new DelegateCommand(
                        (object p) =>
                        {
                            var instance = _controller.CreateNode(nodeClass.FullName);
                            instance.Set(Elements);
                        },
                        (object p) =>
                        {
                            if (attri.Type == NodeMenuAttribute.NodeType.None)
                            {
                                return true;
                            }
                            else if (attri.Type.HasFlag(NodeMenuAttribute.NodeType.Unique))
                            {
                                return _controller.IsNodeExists(attri.Id) == false;
                            }

                            return false;
                        });
                    }

                    var parentContext = ContextMenus.FirstOrDefault(t => t.Name.Equals(parent));

                    if (parentContext != null)
                    {
                        parentContext.Children.Add(context);
                    }
                    else
                    {
                        ContextMenus.Add(context);
                    }

                    parent = pathes[i];
                }
            }
        }
    }
}
