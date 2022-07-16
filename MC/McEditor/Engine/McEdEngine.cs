using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace McEditor.Engine
{
    public static class McEdEngine
    {
        public static void LoopTest()
        {
            int a = 0;
            var timer = new DispatcherTimer(
            TimeSpan.FromSeconds(1 / 60),
            DispatcherPriority.SystemIdle,// Or DispatcherPriority.SystemIdle
            (s, e) =>
            {
                Debug.WriteLine(a);
                ++a;
            }, // or something similar
            Application.Current.Dispatcher);

            timer.Start();
        }
    }
}
