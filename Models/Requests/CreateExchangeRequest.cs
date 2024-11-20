namespace ScalableServiceApiGateway.Models.Requests
{
    public class CreateExchangeRequest
    {
        public int RequestTypeId { get; set; }
        public string SenderBookId { get; set; }
        public string ReceiverBookId { get; set; }
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public int DeliveryMethodId { get; set; }
        public int ExchangeDuration { get; set; }
        public int PaymentMethodId { get; set; }
        public int StatusId { get; set; }
    }
}
