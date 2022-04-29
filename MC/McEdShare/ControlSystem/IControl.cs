// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;

#if WPF
using System.Windows.Controls;
#endif

namespace McEdShare.ControlSystem
{
    public interface IControl
    {
#if WPF
        UserControl Control { get; }
#endif
    }
}
