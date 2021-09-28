using System.Windows;
using System.Windows.Input;
using Programming005.Library.DesktopUI.Models.Configruration;
using Programming005.Library.DesktopUI.Commands.ConfigCommands;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class DbConfigurationViewModel
    {
        public DbConfigurationViewModel(Window configurationWindow)
        {
            this.ConfigObject = new ConfigurationModel();
            this.Window = configurationWindow;

            this.Save = new SaveConfigCommand(this);
            this.Cancel = new CancelConfigCommand(this);
        }

        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

        public Window Window { get; set; }

        public ConfigurationModel ConfigObject { get; set; }

        public string[] DbTypes { get; set; } = { "sql", "firebase" };
    }
}