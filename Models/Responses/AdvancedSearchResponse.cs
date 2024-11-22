using ScalableServiceApiGateway.Models;

public class AdvancedSearchResponse
{
    public List<GetBook> Books { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int TotalBooks { get; set; }
}


