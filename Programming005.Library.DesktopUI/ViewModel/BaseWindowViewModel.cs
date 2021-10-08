using System.Windows;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public abstract class BaseWindowViewModel
    {
        public BaseWindowViewModel(Window window)
        {
            Window = window;
        }

        public Window Window { get; set; }
    }
}
