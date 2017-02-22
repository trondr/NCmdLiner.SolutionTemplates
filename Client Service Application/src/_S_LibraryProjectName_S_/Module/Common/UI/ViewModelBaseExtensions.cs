using System;
using System.Runtime.CompilerServices;
using Common.Logging.Configuration;
using GalaSoft.MvvmLight;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    /// <summary>
    /// Extends Mvvm Ligth Toolkit ViewModelBase class
    /// Credits: Pluralsight Mvvm videos by brian Noyes and 
    /// https://github.com/PrismLibrary/Prism/blob/master/Source/Prism/Mvvm/BindableBase.cs
    /// </summary>
    public static class ViewModelBaseExtensions
    {
        public static void SetProperty<T>(this ViewModelBase viewModel, ref T member, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return;
            member = value;
            viewModel.RaisePropertyChanged(propertyName);
        }

        public static void SetProperty<T>(this ViewModelBase viewModel, ref T member, T value, Action action, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return;
            member = value;
            action?.Invoke();
            viewModel.RaisePropertyChanged(propertyName);
        }
    }
}
