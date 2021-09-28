using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Programming005.Library.DesktopUI.Utils
{
    public class Configuration
    {
        private static Configuration _config;

        private Configuration()
        {

        }

        public string DbType { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }

        public bool IntegratedSecurity { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }


        public static Configuration Get()
        {
            if(_config == null)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                if(File.Exists($"{path}\\programming005app.config") == false)
                {
                    _config = new Configuration();
                }
                else
                {
                    string text = File.ReadAllText($"{path}\\programming005app.config");

                    _config = JsonConvert.DeserializeObject<Configuration>(text);
                }
            }

            return _config;
        }



        public void Save()
        {
            string text = JsonConvert.SerializeObject(this);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            File.WriteAllText($"{path}\\programming005app.config", text);
        }
    }
}
