using Khandar.Application.Abstractions.IRepositories;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Khandar.Persistence.Data;
using Khandar.Persistence.Repositories;

namespace Khandar.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<AppOrder>, IOrderRepository
    {
        private readonly KhandarDbContext context;
        public OrderRepository(KhandarDbContext context) : base(context)
        {
            this.context = context;
        }

        public Task<AppPaymentStatus> GetPaymentStatus(Guid callBookingId)
        {
            return FirstOrDefaultAsync<AppPaymentStatus>(@$"SELECT P.AppPaymentStatus FROM AppOrders O
								                             INNER JOIN AppPayments P
								                             ON O.OrderId = P.RpOrderId
								                             WHERE O.CallBookingId =@callBookingId ", new { callBookingId });
        }

        public Task<int> SaveOrder(AppOrder model)
        {

            return ExecuteAsync<int>(@$"INSERT INTO AppOrders  VALUES 
                        (@Id, @OrderId, @UserId, @AppealId ,@Receipt, @TotalAmount, 
                        @CreatedAt, @Currency,@OrderStatus,
                        @CreatedBy, @UpdatedBy, @CreatedOn,   @UpdatedOn) ", model);
        }
    }
}
