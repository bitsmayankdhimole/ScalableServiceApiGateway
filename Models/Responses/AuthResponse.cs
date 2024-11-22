namespace ScalableServiceApiGateway.Models.Responses
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string AuthToken { get; set; }
        public string Json { get; set; }
    }

    public class Notification
    {
        public string Type { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
}
