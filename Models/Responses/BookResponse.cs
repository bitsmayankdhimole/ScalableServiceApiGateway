namespace ScalableServiceApiGateway.Models.Responses
{
    public class BookResponse
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Owner { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Version { get; set; }
    }
}
