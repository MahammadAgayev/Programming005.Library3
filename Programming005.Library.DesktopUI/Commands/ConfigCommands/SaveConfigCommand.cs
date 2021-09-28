using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Utils;
using Programming005.Library.DesktopUI.ViewModel;
using Programming005.Library.DesktopUI.Views;

namespace Programming005.Library.DesktopUI.Commands.ConfigCommands
{
    public class SaveConfigCommand : ICommand
    {
        private readonly DbConfigurationViewModel _viewModel;

        public SaveConfigCommand(DbConfigurationViewModel viewModel)
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
            var config = Configuration.Get();

            config.Database = _viewModel.ConfigObject.Database;
            config.Server = _viewModel.ConfigObject.Server;
            config.IntegratedSecurity = _viewModel.ConfigObject.IntegratedSecurity;
            config.Username = _viewModel.ConfigObject.Username;
            config.Password = _viewModel.ConfigObject.Password;

            config.Save();

            WindowStart windowStart = new WindowStart();
            windowStart.Show();

            _viewModel.Window.Close();
        }
    }
}
