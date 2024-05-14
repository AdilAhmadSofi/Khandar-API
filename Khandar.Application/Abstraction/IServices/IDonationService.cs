using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices;

public interface IDonationService
{

    Task<APIResponse<AppOrderResponse>> CreateOrder(AppOrderRequest model);

    Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model);

    Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactions();

    Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsByAppealId(Guid appealId);

    Task<APIResponse<IEnumerable<MyTransactionResponse>>> GetMyTransactions(Guid? userId);

    Task<int> GetAllTransactionTotal();

    Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsByDate(DateTimeOffset fromDate, DateTimeOffset toDate);

    Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsAsOfNow(DateTimeOffset toDate);

    Task<APIResponse<IEnumerable<AppealSummaryResponse>>> GetAllAppealSummary(int totalCount);


}


