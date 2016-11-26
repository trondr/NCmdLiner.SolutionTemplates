using System;
using System.Windows;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    public abstract class ViewModelBase : DependencyObject
    {
        public abstract void Load();
        public abstract Action CloseWindow { get; set; }

    }
}
