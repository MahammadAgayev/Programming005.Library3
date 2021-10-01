using System.Collections.Generic;

namespace Programming005.Library.Core.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Programming005.Library.Core.Domain.Entities.User> Users { get; set; }
        public List<Programming005.Library.Core.Domain.Entities.Book> Books { get; set; }
    }
}