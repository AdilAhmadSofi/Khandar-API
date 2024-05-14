using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController : ApiController
    {
        private readonly ITeamMemberService service;

        public TeamMembersController(ITeamMemberService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IResult> InsertAsync(TeamMemberRequest model) => this.APIResult(await service.InsertAsync(model));

        
        [HttpGet("{id:guid}")]
        public async Task<APIResponse<TeamMemberInfoResponse>> GetByIdAsync(Guid id) => await service.GetByMemberIdAsync(id);


        [HttpGet("members/{teamid:guid}")]
        public async Task<APIResponse<IEnumerable<TeamMemberInfoResponse>>> GetAllTeamMembersByTeamId(Guid teamid) => await service.GetAllTeamMembersByTeamId(teamid);
    }
}
