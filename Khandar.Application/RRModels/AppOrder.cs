namespace Khandar.Application.RRModels
{
    public class AppOrderRequest
    {
       public Guid AppealId { get; set; }

        public decimal Amount { get; set; }

        public string? Name { get; set; }

        public string? ContactNo { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        //public AnonymousDonorRequest AnonymousDonorRequest { get; set; }
    }

    public class AppOrderResponse
    {
        public string OrderId { get; set; } = null!;


        public decimal TotalAmount { get; set; }


        public string Name { get; set; }=null!;


        public string Email { get; set; } = null!;


        public string Contact { get; set; } = string.Empty;


        public string Address { get; set; } = string.Empty;


        public string Description { get; set; } = string.Empty;

        public string Receipt { get; set; } = string.Empty;

    }
}
