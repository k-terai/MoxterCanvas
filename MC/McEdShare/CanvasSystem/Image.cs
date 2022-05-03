using System;
using System.Collections.Generic;
using System.Text;

namespace McEdShare.CanvasSystem
{
    public sealed class Image : CanvasElement
    {
        private string _path;

        public string Path { get { return _path; } set { _path = value; NotifyPropertyChanged(); } }
    }
}
