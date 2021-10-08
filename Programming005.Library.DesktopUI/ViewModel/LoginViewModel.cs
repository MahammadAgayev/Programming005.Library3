using System.Windows;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Commands.LoginCommands;
using Programming005.Library.DesktopUI.Models.LoginModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class LoginViewModel : BaseWindowViewModel
    {
        public LoginViewModel(Window window) : base(window)
        {
            Login = new LoginCommand(this);
            LoginModel = new LoginModel
            {
                Username = "admin"
            };
        }

        public ICommand Login { get; set; }

        public LoginModel LoginModel { get; set; }
    }
}