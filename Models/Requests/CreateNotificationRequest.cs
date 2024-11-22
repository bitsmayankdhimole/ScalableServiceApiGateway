namespace ScalableServiceApiGateway.Models.Requests
{
    public class CreateNotificationRequest
    {
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
