﻿using System.Collections.Generic;

namespace Programming005.Library.Core.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Book> Books { get; set; }
    }
}