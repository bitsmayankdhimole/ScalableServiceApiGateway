namespace ScalableServiceApiGateway.Models.Responses
{
    public class PasswordChangeResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public PasswordChangeData Data { get; set; }
    }

    public class PasswordChangeData
    {
        public string Link { get; set; }
    }
}
