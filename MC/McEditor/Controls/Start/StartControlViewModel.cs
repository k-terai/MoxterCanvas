// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEditor.Service;
using McEdShare.ControlSystem;
using McEdShare.CoreSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Controls
{
    public class StartControlViewModel : ControlViewModel
    {
        public DelegateCommand ChangeLanguageCommand { get; set; }

        public StartControlViewModel() : base()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            ChangeLanguageCommand = new DelegateCommand((object p) =>
            {
                switch ((string)p)
                {
                    case ResourceService.ENGLISHCODE:
                        ResourceService.Current.ChangeCulture(ResourceService.ENGLISHCODE);
                        break;

                    case ResourceService.JAPANACECODE:
                        ResourceService.Current.ChangeCulture(ResourceService.JAPANACECODE);
                        break;
                }
            });

        }
    }
}
