namespace Programming005.Library.Core.Domain.Entities
{
    public class AuthorBook
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}