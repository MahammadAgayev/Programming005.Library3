using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming005.Library.DesktopUI.Models.Configruration
{
    public class ConfigurationModel
    {
        public string DbType { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
