using Programming005.Library.DesktopUI.ViewModel;
using Programming005.Library.DesktopUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Programming005.Library.DesktopUI.Commands.LibraryMainWindowCommands
{
    public class OpenBooksCommand : ICommand
    {
        private readonly LibraryMainViewModel _viewModel;

        public OpenBooksCommand(LibraryMainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Grid.Children.Clear();

            var userControl = new BooksUserControl();
            userControl.DataContext = new BookViewModel(userControl);

            _viewModel.Grid.Children.Add(userControl);
        }
    }
}