namespace ScalableServiceApiGateway.Models.Requests
{
    public class UpdateBookRequest
    {
        public string Condition { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class UpdateBookMicroServiceRequest : UpdateBookRequest
    {
        public string UserId { get; set; }
    }
}
