using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationAppealsController : ApiController
    {
        private readonly IDonationAppealService service;

        public DonationAppealsController(IDonationAppealService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IResult> Insert([FromForm] DonationAppealRequest model) => this.APIResult(await service.InsertAsync(model));


        [HttpGet("team-appeals/{teamid:guid}")]
        public async Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetTeamAppeals(Guid teamId) => await service.GetTeamAppeals(teamId);


        //[HttpGet("leader-appeals/{teamid:guid}")]
        //public async Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetAppealsForTeamLeader(Guid teamId) => await service.GetAppealsForTeamLeader(teamId);


        [HttpGet("all-appeals")]
        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllAppeals() => await service.GetAllAppeals();



        [HttpPut("update-appeal-status")]
        public async Task<IResult> UpdateAppealStatus(UpdateAppealStatusRequest model) => this.APIResult(await service.UpdateAppealStatus(model));


        [HttpPut("update-appeal")]
        public async Task<IResult> UpdateAppeal([FromForm] UpdateAppealRequest model) => this.APIResult(await service.UpdateAppeal(model));


        [HttpGet("my-appeal")]
        public async Task<IResult> GetMyAppeal() => this.APIResult(await service.GetMyAppeal());


        [HttpGet("beneficiary-details/{id:guid}")]
        public async Task<IResult> GetBeneficiaryDetails(Guid id) => this.APIResult(await service.GetBeneficiaryDetails(id));


        [HttpGet("Team-Appeals-by-teamid/{teamid:guid}")]
        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllTeamAppeals(Guid teamid) => await service.GetAllTeamAppeals(teamid);



        [HttpGet("Team-Appeals-by-status/{teamid:guid}")]
        public async Task<IResult> GetAllTeamAppeals(Guid teamid, [FromQuery] DonationAppealStatus appealStatus) => this.APIResult(await service.GetAllTeamAppealsByStatus(teamid, appealStatus));


        [HttpGet("all-approved-appeals")]
        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllApprovedAppeals() => await service.GetAllApprovedAppeals();


        [HttpGet("all-appeals-by-status")]
        public async Task<IResult> GetAllAppealsByStatus(DonationAppealStatus appealStatus) => this.APIResult(await service.GetAllAppealsByStatus(appealStatus));


        [HttpGet("total-appeals")]
        public async Task<int> GetTotalAppeals([FromQuery] DonationAppealStatus status) => await service.GetTotalAppeals(status);


        [HttpGet("total-team-appeals/{teamId}")]
        public async Task<int> GetTeamTotalAppeals(Guid teamId, [FromQuery] DonationAppealStatus status) => await service.GetTeamTotalAppeals(teamId, status);

    }
}
