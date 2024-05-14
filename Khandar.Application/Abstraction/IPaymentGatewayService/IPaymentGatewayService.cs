using Khandar.Domain.Entities;
using Khandar.Application.RRModels;

namespace Khandar.Application.Abstractions.IPaymentGatewayService;

public interface IPaymentGatewayService
{
    public AppOrder CreateOrder(AppOrder model);

    public Task<AppPayment> CapturePayment(PaymentDetailsRequest model);


    public Task<IEnumerable<PaymentRefundResponse>> RefundPayment(IEnumerable<string> rpPaymnetIds);
}
