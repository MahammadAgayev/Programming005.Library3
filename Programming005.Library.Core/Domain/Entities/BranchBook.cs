namespace Programming005.Library.Core.Domain.Entities
{
    public class BranchBook
    {
        public int Id { get; set; }
        public Branch Branch { get; set; }
        public Book Book { get; set; }
    }
}