namespace ScalableServiceApiGateway.Models.Responses
{
    public class AdvancedSearchResponse
    {
        public List<BookResponse> Books { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalBooks { get; set; }
    }
}
