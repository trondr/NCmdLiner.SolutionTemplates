using System.Windows.Controls;

namespace _S_LibraryProjectName_S_.Module.Common.UI
{
    public class ViewBase: UserControl
    {
        private ViewModelBase _viewModel;

        protected ViewBase()
        {
            //Loaded+=OnLoaded;
        }

        public ViewModelBase ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        //private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        //{
        //    this.DataContext = this.ViewModel;            
        //}
    }
}
