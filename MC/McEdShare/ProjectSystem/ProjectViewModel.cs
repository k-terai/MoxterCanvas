// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.


using McEdShare.CoreSystem;
using McEdShare.LocalizationSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static McEdShare.CoreSystem.EditorCommon;

namespace McEdShare.ProjectSystem
{
    public class ProjectViewModel : ViewModelBase
    {
        /// <summary>
        /// New project name.
        /// </summary>
        private string _name;

        /// <summary>
        /// New project location.
        /// </summary>
        private string _location;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                var location = Path.Combine(_location, _name);
                var result = Project.IsValidName(_name, location);

                if (result == Result.OK)
                {
                    ClearError();
                }
                else
                {
                    SetErrors(new[] { LocalizationManager.GetString(result) });
                }

                NotifyPropertyChanged();
                NotifyPropertyChanged("ProjectNameError");
            }
        }

        public string Location
        {
            get => _location;
            set
            {
                _location = value;
                var result = Project.IsValidLocation(_location);

                //Check project parent directory exists.
                if (result == Result.OK)
                {
                    ClearError();
                }
                else
                {
                    SetErrors(new[] { LocalizationManager.GetString(result) });
                }

                //Since we want to check the entire path, enter a value in Name and perform a property check.
                if (_name != null)
                {
                    Name = _name;
                }

                NotifyPropertyChanged();
                NotifyPropertyChanged("LocationError");
            }
        }

        public string ProjectNameError
        {
            get
            {
                var e = GetErrors("Name");

                if (e != null)
                {
                    return (e as string[])[0];
                }

                return null;
            }
        }

        public string LocationError
        {
            get
            {
                var e = GetErrors("Location");

                if (e != null)
                {
                    return (e as string[])[0];
                }

                return null;
            }
        }

        public DelegateCommand CreateProjectCommand { get; set; }

        public event Action<Project> OnProjectCreated;

        public ProjectViewModel()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Location = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Name = "NewProject";

            InitCommands();
        }

        private void InitCommands()
        {
            CreateProjectCommand = new DelegateCommand
            (
                (object parametor) =>
                {
                    var p = Project.Create(Name, Location);

                    if (p != null)
                    {
                        OnProjectCreated?.Invoke(p);
                    }
                }
                ,
                (object parametor) =>
                {
                    return !HasErrors;
                }

            );
        }

    }
}
