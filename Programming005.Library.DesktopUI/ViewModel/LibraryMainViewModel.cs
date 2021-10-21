using Programming005.Library.DesktopUI.Commands.LibraryMainWindowCommands;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class LibraryMainViewModel : BaseWindowViewModel
    {
        public LibraryMainViewModel(Window window) : base(window)
        {
            OpenBooks = new OpenBooksCommand(this);
            OpenBranches = new OpenBranchesCommand(this);
        }

        public ICommand OpenBooks { get; set; }
        public ICommand OpenBranches { get; set; }

        public Grid Grid { get; set; }
    }
}
