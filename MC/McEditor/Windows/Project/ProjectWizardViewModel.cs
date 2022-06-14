// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEdShare.CoreSystem;
using McEdShare.ProjectSystem;
using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Windows.Project
{
    public sealed class ProjectWizardViewModel : WindowViewModel
    {
        private ProjectViewModel _projectViewModel;

        public DelegateCommand SelectLocationCommand { get; private set; }
        public DelegateCommand CancelCommand { get; set; }
        public ProjectViewModel ProjectViewModel { get => _projectViewModel; set { _projectViewModel = value; NotifyPropertyChanged(); } }

        public event System.Action OnCancel;

        public ProjectWizardViewModel() : base()
        {
            Width = 1000;
            MinWidth = 800;
            Height = 600;
            MinHeight = 600;
            Title = "Project Wizard";

            ProjectViewModel = new ProjectViewModel();
            InitCommands();
        }

        private void InitCommands()
        {
            ProjectViewModel.OnProjectCreated += (McEdShare.ProjectSystem.Project p) =>
            {
                if (p != null)
                {
                    EditorManager.Restart(p.DataPath);
                }
            };

            SelectLocationCommand = new DelegateCommand(

                 (object p) =>
                 {
                     var path = EditorManager.CreateSelectExternalFolderWindow().ShowWindow("Select new project path.");
                     if (path != string.Empty)
                     {
                         ProjectViewModel.Location = path;
                     }
                 }
                 );

            CancelCommand = new DelegateCommand(

                  (object p) =>
                  {
                      OnCancel?.Invoke();
                  }
                  );
        }
    }
}
