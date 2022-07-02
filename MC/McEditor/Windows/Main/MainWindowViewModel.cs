// Copyright (c) 2022 K.T
// Licensed under the MIT License. See LICENSE in the project root for license information.

using McEditor.Controls;
using McEditor.Dispatcher;
using McEditor.Service;
using McEdShare.AssetSystem;
using McEdShare.ControlSystem;
using McEdShare.CoreSystem;
using McEdShare.TabSystem;
using McEdShare.WindowSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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

        public DelegateCommand CreateStartControlCommand { get; set; }

        public DelegateCommand CreateNewCanvasCommand { get; set; }

        public DelegateCommand OpenCanvasCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand SaveAsCommand { get; set; }

        public DelegateCommand SaveAllCommand { get; set; }

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

                var control = EditorManager.CreateCanvasControl();

                var tab = new TabItemViewModel()
                {
                    Header = "NewCanvas*",
                    ContentControl = control
                };

                TabItems.Add(tab);
                SelectTabIndex = TabItems.Count - 1;

                //var context = new AssetContext("NewCanvas");
                //control.ViewModel.TargetCanvas = AssetDatabase.CreateAsset<Canvas>(context);

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

            SaveCommand = new DelegateCommand(
                (object p) =>
                {
                    //var dialog = EditorManager.CreateSaveFileDialog();
                    //var path = dialog.ShowFileDialog("Test", "Canvas File(*.canvas)|*.canvas;");

                    //if (!string.IsNullOrEmpty(path))
                    //{
                    //    var control = TabItems[SelectTabIndex].AssetControl;
                    //    if (control != null)
                    //    {
                    //        //HACK : Does \\ always enter the pass? 
                    //        var directory = new DirectoryInfo(path.Remove(path.LastIndexOf('\\')));
                    //        Debug.Assert(directory != null);

                    //        control.Target.SetDirectory(directory);

                    //        if (control.Target.Save())
                    //        {
                    //            control.Target.Rename(Path.GetFileNameWithoutExtension(path));
                    //            TabItems[SelectTabIndex].Header = control.Target.DisplayName;
                    //        }
                    //    }
                    //}
                }
                ,
                (object p) =>
                {
                    if (SelectTabIndex < 0)
                    {
                        return false;
                    }

                    if (TabItems[SelectTabIndex].ContentControl is IEditAssetControl control && control.Target != null && control.Target.IsDirty)
                    {
                        return true;
                    }

                    return false;
                }
            );

            SaveAsCommand = new DelegateCommand(
                (object p) =>
                {

                }
                ,
                (object p) =>
                {
                    return true;
                }
            );

            SaveAllCommand = new DelegateCommand(
             (object p) =>
             {

             }
             ,
             (object p) =>
             {
                 return false;
             }
            );

            CreateStartControlCommand = new DelegateCommand(
           (object p) =>
           {
               var control = EditorManager.CreateStartControl();

               var tab = new TabItemViewModel()
               {
                   Header = "Start",
                   ContentControl = control
               };

               TabItems.Add(tab);
               SelectTabIndex = TabItems.Count - 1;
           }
           ,
           (object p) =>
           {
               return true;
           }
          );
        }
    }
}
