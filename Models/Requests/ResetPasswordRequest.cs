namespace ScalableServiceApiGateway.Models.Requests
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
