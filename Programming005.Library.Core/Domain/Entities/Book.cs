using System.Collections.Generic;

namespace Programming005.Library.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public bool IsTranslation { get; set; }

        public List<Programming005.Library.Core.Domain.Entities.Author> Authors { get; set; }
        public List<Programming005.Library.Core.Domain.Entities.Branch> Branches { get; set; }
    }
}