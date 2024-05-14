using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class DonationRepository : BaseRepository<Donation>, IDonationRepository
    {
        public DonationRepository(KhandarDbContext context) : base(context)
        {

        }

        private readonly string transactionQuery = $@" SELECT P.OrderId, UserId AS DonorId, AppealId, Receipt, TransactionId, P.Amount AS PaidAmount,
		                                               U.[Name] AS DonorName,  U.ContactNo AS DonorContactNo,  U.Email AS DonorEmail ,UserRole,
		                                               D.BeneficiaryId, D.CaseNo, D.IsPublic, D.[Description], P.CreatedOn AS TransactionDate
			                                           FROM AppOrders O
			                                           INNER JOIN AppPayments P
			                                           ON O.Id = P.OrderId
			                                           INNER JOIN Users U
			                                           ON U.Id = O.UserId
			                                           INNER JOIN DonationAppeals D
			                                           ON D.Id = O.AppealId   ";


        public async Task<IEnumerable<TransactionResponse>> GetAllTransactions()
        {
           
            return await QueryAsync<TransactionResponse>(transactionQuery +$@" ORDER BY P.CreatedOn DESC ");
        }


        public async Task<IEnumerable<TransactionResponse>> GetAllTransactionsByAppealId(Guid id)
        {
            return await QueryAsync<TransactionResponse>(transactionQuery + $@"  WHERE D.Id = @Id  ORDER BY P.CreatedOn DESC ",new { id });
        }


        public async Task<IEnumerable<MyTransactionResponse>> GetMyTransactions(Guid id)
        {
            string query = $@" SELECT P.OrderId, O.UserId AS DonorId, AppealId, Receipt, TransactionId, P.Amount AS PaidAmount,
		                                 D.BeneficiaryId, D.CaseNo, D.IsPublic, D.[Description], P.CreatedOn AS TransactionDate
			                                  FROM AppOrders O
			                                  INNER JOIN AppPayments P
			                                  ON O.Id = P.OrderId
			                                  INNER JOIN DonationAppeals D
			                                  ON D.Id = O.AppealId 
											  WHERE O.UserId= @id  ORDER BY P.CreatedOn DESC ";

            return await QueryAsync<MyTransactionResponse>(query , new { id });
        }

        public async Task<int> GetAllTransactionTotal()
        {
           return await FirstOrDefaultAsync<int>("SELECT SUM(Amount) AS TotalAmountRecieved FROM  AppPayments ");
        }

        public async Task<IEnumerable<TransactionResponse>> GetAllTransactionsByDate(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            return await QueryAsync<TransactionResponse>(transactionQuery + $@"	WHERE   CAST(P.CreatedOn AS date) >= CAST(@fromDate AS date)  AND CAST(P.CreatedOn AS date) <= CAST(@toDate AS date) ORDER BY P.CreatedOn DESC ", new { fromDate,toDate });
        }

        public async Task<IEnumerable<TransactionResponse>> GetAllTransactionsAsOfNow(DateTimeOffset toDate)
        {
            return await QueryAsync<TransactionResponse>(transactionQuery + $@" WHERE  CAST(P.CreatedOn AS date) <= CAST(@toDate  AS date)  ORDER BY P.CreatedOn DESC ", new { toDate });
        }

        public async Task<IEnumerable<AppealSummaryResponse>> GetAllAppealSummary(int totalCount)
        {
            string query = $@" SELECT  COUNT(O.UserId) AS Donors, SUM(P.Amount) AS Amount,D.CaseNo
			                                  FROM AppOrders O
			                                  INNER JOIN AppPayments P
			                                  ON O.Id = P.OrderId
			                                  INNER JOIN DonationAppeals D
			                                  ON D.Id = O.AppealId 
											  GROUP BY D.CaseNo  ";

            return await QueryAsync<AppealSummaryResponse>(query);
        }
    }
}
