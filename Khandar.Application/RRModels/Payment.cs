using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using System.Transactions;

namespace Khandar.Application.RRModels;

public class PaymentDetailsRequest
{
    public string razorpay_payment_id { get; set; } = string.Empty;

    public string razorpay_order_id { get; set; } = string.Empty;

    public string razorpay_signature { get; set; } = string.Empty;
}

public class PaymentDetailsResponse
{
    public bool IsPaymentSuccessfull { get; set; }

}


public class PaymentRefundRequest
{
    public List<string> RpPaymentId { get; set; } = null!;

}

public class PaymentRefundResponse
{
    public string TransactionId { get; set; } = string.Empty;

    public bool isRefunded { get; set; }

}

public class UserPaymentRefundRequest
{
    public Guid OrderId { get; set; }
}


public class TransactionResponse
{
    public Guid OrderId { get; set; }

    public string TransactionId { get; set; } = string.Empty;

    public Guid DonorId { get; set; }

    public Guid AppealId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public decimal PaidAmount { get; set; }

    public string DonorName { get; set; } = string.Empty;

    public string DonorContactNo { get; set; } = string.Empty;

    public string DonorEmail { get; set; } = string.Empty;

    public UserRole UserRole { get; set; }

    public Guid BeneficiaryId { get; set; }

    public string CaseNo { get; set; } = string.Empty;

    public string Description { get; set; }=string.Empty;

    public DateTimeOffset TransactionDate { get; set; }

    public bool IsPublic { get; set; }
}

public class MyTransactionResponse
{

    public Guid OrderId { get; set; }

    public string TransactionId { get; set; } = string.Empty;

    public Guid DonorId { get; set; }

    public Guid AppealId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public decimal PaidAmount { get; set; }


    public Guid BeneficiaryId { get; set; }

    public string CaseNo { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTimeOffset TransactionDate { get; set; }

    public bool IsPublic { get; set; }
}


public class AppealSummaryResponse
{
    public string CaseNo { get; set; }
    public decimal Amount { get; set; }
    public int Donors { get; set; }
}
