using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ApiController
    {
        private readonly ITeamService service;

        public TeamsController(ITeamService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IResult> InsertAsync(TeamRequest model) => this.APIResult(await service.InsertAsync(model));


        [HttpGet("{id:guid}")]
        public async Task<APIResponse<TeamResponse>> GetByIdAsync(Guid id) => await service.GetByIdAsync(id);


        [HttpGet]
        public async Task<IResult> GetAllAsync() => this.APIResult(await service.GetAllAsync());



        [HttpGet("member-id")]
        public async Task<IResult> GetMyTeamsAsync([FromQuery] Guid? id) => this.APIResult(await service.GetMyTeams(id));


    }
}
