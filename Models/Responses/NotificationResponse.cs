namespace ScalableServiceApiGateway.Models.Responses
{
    public class NotificationResponse
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
