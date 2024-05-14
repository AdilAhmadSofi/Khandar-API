using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstractions.IRepositories
{
    public interface IOrderRepository:IBaseRepository<AppOrder>
    {
        Task<int> SaveOrder(AppOrder model);

        Task<AppPaymentStatus> GetPaymentStatus(Guid callBookingId);
    }
}
