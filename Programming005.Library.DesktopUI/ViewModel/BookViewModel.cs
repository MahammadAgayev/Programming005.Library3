using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using Programming005.Library.Core;
using Programming005.Library.DesktopUI.Commands.BookCommands;
using Programming005.Library.DesktopUI.Models.BookModels;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class BookViewModel : BaseUserControlViewModel
    {
        public BookViewModel(UserControl control) : base(control)
        {
            var entites = Kernel.DB.BookRepository.Get();

            Books = new ObservableCollection<BookModel>();

            int counter = 1;
            foreach (var item in entites)
            {
                Books.Add(new BookModel
                {
                    Id = item.Id,
                    Genre = item.Genre,
                    IsTranslation = item.IsTranslation,
                    Language = item.Language,
                    Name = item.Name,
                    No = counter++
                });
            }

            ExportBooks = new ExportBooksCommand(this);
        }

        public ObservableCollection<BookModel> Books { get; set; }

        public BookModel SelectedModel { get; set; }

        public ICommand ExportBooks { get; set; }
    }
}
