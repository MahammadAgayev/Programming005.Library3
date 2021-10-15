using System.Windows.Controls;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public abstract class BaseUserControlViewModel
    {
        protected UserControl UserControl { get; set; }

        public BaseUserControlViewModel(UserControl userControl)
        {
            this.UserControl = userControl;
        }
    }
}
