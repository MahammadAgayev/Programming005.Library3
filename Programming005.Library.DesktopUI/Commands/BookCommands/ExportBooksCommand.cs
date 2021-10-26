using Programming005.Library.DesktopUI.Utils;
using Programming005.Library.DesktopUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Programming005.Library.DesktopUI.Commands.BookCommands
{
    public class ExportBooksCommand : ICommand
    {
        private readonly BookViewModel _bookViewModel;

        public ExportBooksCommand(BookViewModel viewModel)
        {
            _bookViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string path = CsvExporter.Export(_bookViewModel.Books.ToArray(), "books");

            MessageBox.Show($"Exported to {path}", "Success", 
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
