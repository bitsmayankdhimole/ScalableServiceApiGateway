namespace ScalableServiceApiGateway.Models.Responses
{
    public class BookResponse
    {
        public List<Book> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalBooks { get; set; }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public Owner Owner { get; set; }
        public string _id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Version { get; set; }
    }

    public class Owner
    {
        public string _id { get; set; }
        public string Username { get; set; }
    }
}
