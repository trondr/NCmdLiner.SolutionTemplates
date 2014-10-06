using System.Windows;
using Common.Logging;
using _S_LibraryProjectName_S_.ViewModels;
using _S_LibraryProjectName_S_.Views;

namespace _S_LibraryProjectName_S_.Commands.Example
{
    public class Something : ISomething
    {
        private readonly MainWindow _mainWindow;        
        private readonly ILog _logger;

        public Something(MainWindow mainWindow, ILog logger)
        {
            _mainWindow = mainWindow;
            _logger = logger;
        }


        public int Create(string targetRootFolder)
        {
            var returnValue = 0;
            _logger.Info("Showing main window as an example user interface.");
            var application = new Application();
            application.Run(_mainWindow);
            var viewModel = _mainWindow.View.ViewModel as MainViewModel;
            if (viewModel != null)
            {
                _logger.Info("Getting info from the user interface and do something with it: " + viewModel.ProductDescription);
            }
            else
            {
                _logger.Fatal("Fatal error. MainView model returned from dialog was null");
                returnValue = 2;
            }            
            return returnValue;
        }
    }
}