using System.Windows.Input;
using Programming005.Library.DesktopUI.Commands.LoginCommands;
using Programming005.Library.DesktopUI.Models.LoginModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Login = new LoginCommand(this);
            LoginModel = new LoginModel
            {
                Username = "test"
            };
        }

        public ICommand Login { get; set; }

        public LoginModel LoginModel { get; set; }
    }
}
