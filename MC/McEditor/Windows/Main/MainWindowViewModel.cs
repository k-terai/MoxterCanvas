// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEditor.Engine;
using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Windows.Main
{
    internal class MainWindowViewModel : WindowViewModel
    {
        public MainWindowViewModel() : base()
        {
            //ClosingCommand = new McEdShare.CoreSystem.DelegateCommand((object p) =>
            //{
            //    McEdEngine.Shutdown();
            //});
        }
    }
}
