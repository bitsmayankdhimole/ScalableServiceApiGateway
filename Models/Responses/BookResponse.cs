namespace ScalableServiceApiGateway.Models.Responses
{
    public class BookResponse
    {
        public List<GetBook> Books { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalBooks { get; set; }
    }

}
