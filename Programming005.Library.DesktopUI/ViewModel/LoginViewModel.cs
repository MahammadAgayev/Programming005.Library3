using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Models.LoginModels;
using Programming005.Library.DesktopUI.Commands.LoginCommands;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            Login = new LoginCommand(this);
            LoginModel = new LoginModel();
        }

        public ICommand Login { get; set; }

        public LoginModel LoginModel { get; set; }
    }
}
