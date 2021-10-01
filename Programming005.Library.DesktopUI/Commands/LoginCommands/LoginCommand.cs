using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programming005.Library.DesktopUI.ViewModel;
using System.Windows.Controls;
using Programming005.Library.DesktopUI.Views;

namespace Programming005.Library.DesktopUI.Commands.LoginCommands
{
    public class LoginCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            _loginViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            string username = "admin";
            string password = "12345";

            var passwordBox = (PasswordBox)parameter;
            string inputPassword = passwordBox.Password;
            string inputUsername = _loginViewModel.LoginModel.Username;

            if (inputPassword == password && inputUsername == username)
            {
                BranchesWindow window = new BranchesWindow();
                window.DataContext = new BranchViewModel();

                window.Show();
            }
        }
    }
}
