using Khandar.Application;
using Khandar.Domain.Enums;

namespace Khandar.Domain.Entities
{
    public class Donation : BaseModel
    {
        public Guid AppealId { get; set; }

        public Guid? EntityId { get; set; }

        public string? Name { get; set; } = null!;

        public PaymentMode PaymentMode { get; set; }

        public string? Bank { get; set; }

        public decimal Amount { get; set; }

        public string? TransactionId { get; set; }

        public string Reciept { get; set; } = null!;

        public string OrderId { get; set; } = string.Empty;

        //public bool IsGuest { get; set; }
    }
}
