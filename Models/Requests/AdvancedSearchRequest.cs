namespace ScalableServiceApiGateway.Models.Requests
{
    public class AdvancedSearchRequest
    {
        public string Query { get; set; }
        public string Genre { get; set; }
        public string Location { get; set; }
        public string Availability { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
