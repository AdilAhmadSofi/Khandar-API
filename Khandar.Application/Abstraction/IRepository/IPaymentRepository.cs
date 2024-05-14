using Khandar.Domain.Entities;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;

namespace Khandar.Application.Abstractions.IRepository
{
    public interface IPaymentRepository: IBaseRepository<AppPayment>
    {
    }
}
