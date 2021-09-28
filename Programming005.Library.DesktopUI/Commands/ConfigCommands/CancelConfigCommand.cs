using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programming005.Library.DesktopUI.ViewModel;

namespace Programming005.Library.DesktopUI.Commands.ConfigCommands
{
    public class CancelConfigCommand : ICommand
    {
        private readonly DbConfigurationViewModel _viewModel;

        public CancelConfigCommand(DbConfigurationViewModel viewModel)
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
            _viewModel.Window.Close();
        }
    }
}
