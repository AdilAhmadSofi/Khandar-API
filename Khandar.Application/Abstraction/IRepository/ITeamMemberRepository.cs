using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface ITeamMemberRepository : IBaseRepository<TeamMember>
    {
        Task<TeamMemberInfoResponse> GetByMemberIdAsync(Guid id);

        Task<IEnumerable<TeamMemberInfoResponse>> GetAllTeamMembersByTeamId(Guid teamId);
    }
}

