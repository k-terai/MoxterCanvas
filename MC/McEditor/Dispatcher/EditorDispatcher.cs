// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace McEditor.Dispatcher
{
    public static class EditorDispatcher
    {
        public static void Execute(Action action, DispatcherPriority priority)
        {
            Application.Current.Dispatcher.Invoke(
                                 action, priority, new object[]
                                 {

                                 });
        }
    }
}
