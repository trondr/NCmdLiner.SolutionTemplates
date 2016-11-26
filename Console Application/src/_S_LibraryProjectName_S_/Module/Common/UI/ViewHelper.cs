using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    public static class ViewHelper
    {
        public static void LoadViewModel(UserControl view, ViewModelBase viewModel)
        {
            if (view == null) throw new ArgumentNullException(nameof(view));
            if (viewModel == null)
            {
                var msg = string.Format("The property '{0}.ViewModel' of type '{1}' has not been initialized. Please check if '{1}' is registered with the IOC container.", view.GetType().Name, viewModel.GetType().Name);
                throw new Exception(msg);
            }
            view.DataContext = viewModel;
            viewModel.CloseWindow += delegate { CloseWindow(view); };
            viewModel.Load();            
        }
        public static void CloseWindow(UserControl view)
        {
            var window = Window.GetWindow(view);
            if (window != null)
            {
                if (ComponentDispatcher.IsThreadModal)
                {
                    window.DialogResult = true;
                }
                window.Close();
            }
        }
    }
}