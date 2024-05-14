using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstractions.IRepositories;

public interface IHobbyRepository : IBaseRepository<Hobby>
{
    Task<IEnumerable<HobbyResponse>> GetHobbiesById(Guid id);

}
