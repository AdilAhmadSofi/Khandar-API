using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamAssignmentsController : ApiController
    {
        private readonly ITeamAssignmentService service;

        public TeamAssignmentsController(ITeamAssignmentService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<APIResponse<TeamAssignmentResponse>> AssignTeam(TeamAssignmentRequest model) => await service.AssignTeam(model);


        [HttpGet]
        public async Task<APIResponse<IEnumerable<TeamAssignedAppealResponse>>> GetTeamAssignedAppeals() => await service.GetTeamAssignedAppeals();

    }
}
