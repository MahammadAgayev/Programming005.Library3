using Programming005.Library.Core;
using Programming005.Library.DesktopUI.Models.BookModels;
using System.Collections.ObjectModel;
using System.Windows;

namespace Programming005.Library.DesktopUI.ViewModel
{
    public class BookViewModel : BaseWindowViewModel
    {
        public BookViewModel(Window window) : base(window)
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
        }

        public ObservableCollection<BookModel> Books { get; set; }

        public BookModel SelectedModel { get; set; }
    }
}
