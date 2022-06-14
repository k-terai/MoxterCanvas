// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Commands
{
    public static partial class EditorCommand
    {
        public static Dictionary<string, DelegateCommand> AllCommands { get; private set; } = new Dictionary<string, DelegateCommand>();

        public static void Initialize()
        {
            InitCommonCommands();
            InitProjectCommands();
        }
    }
}
