namespace TestBupha3.Models
{
    public enum BookType
    {
        AdultBook,
        ChildrenBook
    }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public BookType Type => Owner.IsAdult ? BookType.AdultBook : BookType.ChildrenBook; // Automatically assigned based on Owner
    }
}
