using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class DonationRequest
    {
        public string? Name { get; set; }

        public PaymentMode PaymentMode { get; set; }

        public string? Bank { get; set; }

        public decimal Amount { get; set; }
    }
    public class DonationResponse : DonationRequest
    {
        public string? TransactionId { get; set; }

        public string Reciept { get; set; } = null!;

        public string OrderId { get; set; } = string.Empty;

        public DateTimeOffset Date { get; set; }

    }


    public class MemberDonationResponse : DonationRequest
    {
        public Guid DonationId { get; set; }
        public Guid AppealId { get; set; }
        public Guid BeneficiaryId { get; set; }
        public DateTimeOffset DonationDate { get; set; }

    }
}