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

namespace McEditor.Controls
{
    public class CanvasControlViewModel : ControlViewModel
    {
        private ObservableCollection<CanvasElement> _elements;
        private Canvas _targetCanvas;

        public ObservableCollection<CanvasElement> Elements { get => _elements; set { _elements = value; NotifyPropertyChanged(); } }

        public DelegateCommand TestCommand { get; set; }
        public Canvas TargetCanvas { get => _targetCanvas; set { _targetCanvas = value; NotifyPropertyChanged(); } }

        public CanvasControlViewModel() : base()
        {
            Elements = new ObservableCollection<CanvasElement>();
            InitCommands();
        }

        private void InitCommands()
        {
            TestCommand = new DelegateCommand((object p) =>
            {
                Elements.Clear();
                var r = new Random();
                var vectors = new List<Vector2>();

                bool isRectangle = true;
                int count = 500;

                for (int i = 0; i < count; i++)
                {
                    var x = r.Next(0, 1500);
                    var y = r.Next(0, 1500);
                    vectors.Add(new Vector2(x + 25, y + 25));

                    if (isRectangle)
                    {
                        var rec = new Rectangle()
                        {
                            Width = 50,
                            Height = 50,
                            X = x,
                            Y = y,
                            Fill = new SolidColorBrush(new Color()
                            {
                                A = 0,
                                R = (byte)r.Next(0, 255),
                                G = (byte)r.Next(0, 255),
                                B = (byte)r.Next(0, 255),
                            }),
                            Stroke = new SolidColorBrush(new Color()
                            {
                                A = 255 / 2,
                                R = (byte)r.Next(0, 255),
                                G = (byte)r.Next(0, 255),
                                B = (byte)r.Next(0, 255),
                            }),
                            StrokeThickness = 2
                        };
                        Elements.Add(rec);
                    }
                    else
                    {
                        var ellipse = new Ellipse()
                        {
                            Width = 50,
                            Height = 50,
                            X = x,
                            Y = y,
                            Fill = new SolidColorBrush(new Color()
                            {
                                A = 0,
                                R = (byte)r.Next(0, 255),
                                G = (byte)r.Next(0, 255),
                                B = (byte)r.Next(0, 255),
                            }),
                            Stroke = new SolidColorBrush(new Color()
                            {
                                A = 255 / 2,
                                R = (byte)r.Next(0, 255),
                                G = (byte)r.Next(0, 255),
                                B = (byte)r.Next(0, 255),
                            }),
                            StrokeThickness = 2
                        };

                        Elements.Add(ellipse);
                    }

                    isRectangle = !isRectangle;
                }

                for (int i = 0; i < count; i += 2)
                {
                    var cx = vectors[i].X + 100;
                    var cy = vectors[i].Y + 100;
                    var cx1 = vectors[i + 1].X - 100;
                    var cy1 = vectors[i + 1].Y - 100;


                    var data = string.Format("M {0},{1} C {2},{3} {4},{5} {6},{7}", vectors[i].X, vectors[i].Y, cx, cy, cx1, cy1, vectors[i + 1].X, vectors[i + 1].Y);
                    var path = new Path()
                    {
                        Width = 10000,
                        Height = 10000,
                        X = r.Next(0, 0),
                        Y = r.Next(0, 0),
                        Data = data,
                        Stroke = new SolidColorBrush(new Color()
                        {
                            A = 255 / 2,
                            R = (byte)r.Next(0, 255),
                            G = (byte)r.Next(0, 255),
                            B = (byte)r.Next(0, 255),
                        }),
                        StrokeThickness = 2
                    };

                    Elements.Add(path);
                }

                {
                    var text = new NormalText();
                    text.Width = 100;
                    text.Height = 200;
                    text.Text = "Update";
                    text.Foreground = new SolidColorBrush(Colors.Blue);
                    text.Background = new SolidColorBrush(Colors.Transparent);
                    text.IsReadOnly = true;
                    Elements.Add(text);
                }
            });
        }
    }
}
