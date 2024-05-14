using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstractions.IRepositories;

public interface IAddressRepository : IBaseRepository<Address>
{
    Task<IEnumerable<AddressResponse>> GetAddressesById(Guid id);

}
