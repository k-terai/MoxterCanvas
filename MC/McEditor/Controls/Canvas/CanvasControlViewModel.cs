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

namespace McEditor.Controls
{
    public class CanvasControlViewModel : ControlViewModel
    {
        private ObservableCollection<CanvasElement> _elements;

        public ObservableCollection<CanvasElement> Elements { get => _elements; set { _elements = value; NotifyPropertyChanged(); } }

        public DelegateCommand TestCommand { get; set; }

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

                for (int i = 0; i < 1000; i++)
                {
                    var rec = new Rectangle()
                    {
                        Width = 50,
                        Height = 50,
                        X = r.Next(0, 1500),
                        Y = r.Next(0, 1500),
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

                for (int i = 0; i < 1000; i++)
                {
                    var rec = new Ellipse()
                    {
                        Width = 50,
                        Height = 50,
                        X = r.Next(0, 1500),
                        Y = r.Next(0, 1500),
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

                for (int i = 0; i < 10; i++)
                {
                    var rec = new Image()
                    {
                        Width = 50,
                        Height = 50,
                        X = r.Next(0, 1500),
                        Y = r.Next(0, 1500),
                        Path = "TestGo"
                    };

                    Elements.Add(rec);
                }
            });
        }
    }
}
