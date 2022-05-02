// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.


using McEditor.Controls;
using McEditor.Dispatcher;
using McEditor.Service;
using McEdShare.CoreSystem;
using McEdShare.TabSystem;
using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McEditor.Windows
{
    public class MainWindowViewModel : WindowViewModel
    {
        private ObservableCollection<TabItemViewModel> _tabItems;
        private int _selectTabIndex;

        public DelegateCommand ChangeLanguageCommand { get; set; }

        public DelegateCommand CreateNewCanvasCommand { get; set; }

        public DelegateCommand OpenCanvasCommand { get; set; }

        public ObservableCollection<TabItemViewModel> TabItems { get => _tabItems; set { _tabItems = value; NotifyPropertyChanged(); } }

        public int SelectTabIndex { get => _selectTabIndex; set { _selectTabIndex = value; NotifyPropertyChanged(); } }

        public MainWindowViewModel() : base()
        {
            TabItems = new ObservableCollection<TabItemViewModel>();
            SelectTabIndex = -1;
            InitCommand();
        }

        private void InitCommand()
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

            CreateNewCanvasCommand = new DelegateCommand((object p) =>
            {
                var tab = new TabItemViewModel()
                {
                    Header = "NewCanvas*",
                    ContentControl = new CanvasControl()
                };

                TabItems.Add(tab);
                SelectTabIndex = TabItems.Count - 1;

                ////NOTE : It is not reflected in the UI(Tab focus), execute it with Dispatcher.
                //EditorDispatcher.Execute(() =>
                //{
                   
                //},
                // System.Windows.Threading.DispatcherPriority.Render
                //);

            });

            OpenCanvasCommand = new DelegateCommand((object p) =>
            {

            });
        }
    }
}
