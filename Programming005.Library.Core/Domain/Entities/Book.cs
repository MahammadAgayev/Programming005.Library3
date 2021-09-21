﻿using System.Collections.Generic;

namespace Programming005.Library.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public bool IsTranslation { get; set; }

        public List<Author> Authors { get; set; }
        public List<Branch> Branches { get; set; }
    }
}