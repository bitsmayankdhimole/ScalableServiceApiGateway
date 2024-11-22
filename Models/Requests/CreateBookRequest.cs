namespace ScalableServiceApiGateway.Models.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Condition { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateBookMicroserviceRequest : CreateBookRequest
    {
        public string UserId { get; set; }
    }
}
