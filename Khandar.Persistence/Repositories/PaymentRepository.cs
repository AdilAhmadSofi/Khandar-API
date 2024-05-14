using Khandar.Domain.Entities;
using Khandar.Application.Abstractions.IRepository;
using Khandar.Persistence.Repositories;
using Khandar.Persistence.Data;
using Khandar.Application.RRModels;

namespace Khandar.Persistence.Repositories
{
    public class PaymentRepository : BaseRepository<AppPayment>, IPaymentRepository
    {
        private readonly KhandarDbContext context;

        public PaymentRepository(KhandarDbContext context) : base(context)
        {
            this.context = context;
        }

      
    }
}
