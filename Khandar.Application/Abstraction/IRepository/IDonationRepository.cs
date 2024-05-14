using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IDonationRepository:IBaseRepository<Donation>
    {
        Task<IEnumerable<TransactionResponse>> GetAllTransactions();

        Task<IEnumerable<TransactionResponse>> GetAllTransactionsByAppealId(Guid id);

        Task<int> GetAllTransactionTotal();

        Task<IEnumerable<TransactionResponse>> GetAllTransactionsByDate(DateTimeOffset fromDate, DateTimeOffset toDate);

        Task<IEnumerable<MyTransactionResponse>> GetMyTransactions(Guid id);

        Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsOfNow(DateTimeOffset toDate);

        Task<IEnumerable<AppealSummaryResponse>> GetAllAppealSummary(int totalCount);

    }
}
