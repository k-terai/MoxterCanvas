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
        private static IntPtr s_dllPtr = IntPtr.Zero;
        private static bool s_isInitialized = false;

        private delegate bool McEdStartup();
        private delegate bool McEdShutdown();
        private delegate bool McEdInitialize();
        private delegate void McEdUpdate();

        private static McEdStartup s_startup = null;
        private static McEdShutdown s_shutdown = null;
        private static McEdInitialize s_initialize = null;
        private static McEdUpdate s_update = null;

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
                s_dllPtr = NativeMethods.LoadLibrary(engineDllPath);
                break;
            }

            if (string.IsNullOrEmpty(engineDllPath) || s_dllPtr == IntPtr.Zero)
            {
                return false;
            }

            s_startup = GetNativeDelegate<McEdStartup>();
            s_shutdown = GetNativeDelegate<McEdShutdown>();
            s_initialize = GetNativeDelegate<McEdInitialize>();
            s_update = GetNativeDelegate<McEdUpdate>();

            if (s_startup())
            {
                s_initialize();
            }

            s_isInitialized = true;
            ExecuteEngineLoop();

            return true;
        }

        public static void Shutdown()
        {
            if (s_isInitialized)
            {
                s_shutdown();

                NativeMethods.FreeLibrary(s_dllPtr);
                s_dllPtr = IntPtr.Zero;
                s_isInitialized = false;
            }
        }

        private static void ExecuteEngineLoop()
        {
            if (s_isInitialized == false)
            {
                return;
            }

            var timer = new DispatcherTimer(
            TimeSpan.FromSeconds(1 / 60),
            DispatcherPriority.SystemIdle,// Or DispatcherPriority.SystemIdle
            (s, e) =>
            {
                s_update();
            }, // or something similar
            Application.Current.Dispatcher);

            timer.Start();
        }

        private static T GetNativeDelegate<T>()
            where T : Delegate
        {
            Debug.Assert(s_dllPtr != IntPtr.Zero);
            return (T)Marshal.GetDelegateForFunctionPointer(NativeMethods.GetProcAddress(s_dllPtr, typeof(T).Name), typeof(T));
        }

        private static class NativeMethods
        {

            [DllImport("kernel32.dll")]
            public static extern IntPtr LoadLibrary(string lpFileName);

            [DllImport("kernel32.dll")]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hLibModule);
        }
    }
}
