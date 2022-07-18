using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace McEditor.Engine
{
    public static class McEdEngine
    {
        private const string ENGINE_DLL_NAME = "McEdEngine.dll";

        private static IntPtr _dllPtr = IntPtr.Zero;
        private static bool _isInitialized = false;

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

        public static bool Startup()
        {
            var exeFileInfo = AssemblyUtility.GetExeFileInfo();
            var directory = exeFileInfo.Directory;
            var engineDllPath = string.Empty;


            while (directory != null)
            {
                var files = directory.GetFiles("*.dll", System.IO.SearchOption.TopDirectoryOnly);
                var dllFile = files.FirstOrDefault(t => t.Name.Equals(ENGINE_DLL_NAME));
                directory = directory.Parent;

                if (dllFile == null)
                {
                    continue;
                }

                engineDllPath = dllFile.FullName;
                _dllPtr = LoadLibrary(engineDllPath);
                break;
            }

            if (string.IsNullOrEmpty(engineDllPath) || _dllPtr == IntPtr.Zero)
            {
                return false;
            }


            return _isInitialized = true;
        }

        public static void Shutdown()
        {
            if (_isInitialized)
            {
                FreeLibrary(_dllPtr);
                _dllPtr = IntPtr.Zero;
                _isInitialized = false;
            }
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll")]
        static extern bool FreeLibrary(IntPtr hLibModule);
    }
}
