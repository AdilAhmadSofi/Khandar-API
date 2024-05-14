using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface ITeamMemberService
    {
        Task<APIResponse<TeamMemberResponse>> InsertAsync(TeamMemberRequest model);

        Task<APIResponse<TeamMemberInfoResponse>> GetByMemberIdAsync(Guid id);

        Task<APIResponse<IEnumerable<TeamMemberInfoResponse>>> GetAllTeamMembersByTeamId(Guid teamId);

        Task<APIResponse<string>> AssignTeamLeader(Guid memberId);
    }
}
