using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface ITeamRepository:IBaseRepository<Team>
    {
        Task<IEnumerable<TeamResponse>> GetMyTeamsAsync(Guid memberId);
    }
}
