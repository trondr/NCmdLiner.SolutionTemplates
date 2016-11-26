using System;
using System.Windows;
using System.Windows.Input;
using _S_LibraryProjectName_S_.Module.Common.UI;
using _S_LibraryProjectName_S_.Module.Views;

namespace _S_LibraryProjectName_S_.Module.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel()
        {
            
        }

        public static readonly DependencyProperty ProductDescriptionProperty = DependencyProperty.Register(
            "ProductDescription", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

        public string ProductDescription
        {
            get { return (string)GetValue(ProductDescriptionProperty); }
            set { SetValue(ProductDescriptionProperty, value); }
        }

        public static readonly DependencyProperty ProductDescriptionLabelTextProperty = DependencyProperty.Register(
            "ProductDescriptionLabelText", typeof(string), typeof(MainViewModel), new PropertyMetadata(default(string)));

        public string ProductDescriptionLabelText
        {
            get { return (string)GetValue(ProductDescriptionLabelTextProperty); }
            set { SetValue(ProductDescriptionLabelTextProperty, value); }
        }

        public static readonly DependencyProperty MaxLabelWidthProperty = DependencyProperty.Register(
            "MaxLabelWidth", typeof(int), typeof(MainViewModel), new PropertyMetadata(default(int)));

        public int MaxLabelWidth
        {
            get { return (int)GetValue(MaxLabelWidthProperty); }
            set { SetValue(MaxLabelWidthProperty, value); }
        }

        public ICommand OkCommand { get; set; }

        
        public override void Load()
        {
            ProductDescriptionLabelText = "Product Description:";
            ProductDescription = "My Product";
            MaxLabelWidth = 200 ;
            OkCommand = new CommandHandler(this.CloseWindow, true);
        }

        public override Action CloseWindow { get; set; }
    }
}