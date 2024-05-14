using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public  interface ITeamAssignmentService
    {
        Task<APIResponse<IEnumerable<TeamAssignedAppealResponse>>> GetTeamAssignedAppeals();


        Task<APIResponse<TeamAssignmentResponse>> AssignTeam(TeamAssignmentRequest model);


    }
}
