using Khandar.Domain.Entities;
using Khandar.Application;
using Khandar.Domain.Enums;
using System.Collections.Generic;

namespace Khandar.Domain.Entities;

public class AppOrder : BaseModel
{
    public string OrderId { get; set; } = string.Empty;

    public Guid? UserId { get; set; }

    public Guid AppealId { get; set; }

    public string Receipt { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }


    public int CreatedAt { get; set; }

    public string Currency { get; set; } = "INR";

    public AppOrderStatus OrderStatus { get; set; }


    public ICollection<AppPayment> Payments { get; set; } = null!;
}
