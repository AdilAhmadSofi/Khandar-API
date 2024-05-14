using System.ComponentModel.DataAnnotations.Schema;
using Khandar.Application;
using Khandar.Domain.Enums;

namespace Khandar.Domain.Entities;

public class AppPayment : BaseModel
{
    public string TransactionId { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "INR";


    public PaymentMethod PaymentMethod { get; set; }

    public AppPaymentStatus AppPaymentStatus { get; set; }

    public string RpOrderId { get; set; } = string.Empty;


    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public AppOrder Order { get; set; } = null!;

}
