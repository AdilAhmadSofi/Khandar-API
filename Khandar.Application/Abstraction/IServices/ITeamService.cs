using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface ITeamService
    {
        Task<APIResponse<TeamResponse>> InsertAsync(TeamRequest model);
        Task<APIResponse<IEnumerable<TeamResponse>>> GetAllAsync();
        Task<APIResponse<TeamResponse>> GetByIdAsync(Guid id);
        Task<APIResponse<IEnumerable<TeamResponse>>> GetMyTeams(Guid? id);
    }
}
