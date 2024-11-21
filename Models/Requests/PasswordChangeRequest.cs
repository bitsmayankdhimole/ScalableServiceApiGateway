namespace ScalableServiceApiGateway.Models.Requests
{
    public class PasswordChangeRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
