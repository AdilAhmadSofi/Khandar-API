using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppealVerificationsController : ApiController
    {
        private readonly IAppealVerificationService service;

        public AppealVerificationsController(IAppealVerificationService service)
        {
            this.service = service;
        }

        [HttpPost("verify-appeal")]
        public async Task<IResult> VerifyAppeal(AppealVerificationRequest model) => this.APIResult(await service.VerifyAppeal(model));


        [HttpPut("approve-appeal-leader")]
        public async Task<APIResponse<AppealVerificationResponse>> ApproveAppealByLeader(ApproveAppealLeaderRequest model) => await service.AppealApproveByLeader(model);

        [HttpGet("verifications/{teamAssignmentId:guid}")]
       public async Task<APIResponse<IEnumerable<AppealMemberVerificationResponse>>> GetAllVerifications(Guid teamAssignmentId) => await service.GetAllVerifications(teamAssignmentId);


        [HttpGet("member-verification/{teamAssignmentId:guid}")]
        public async Task<IResult> GetMemberVerificationsByMemberId(Guid teamAssignmentId) =>this.APIResult(await service.GetMemberVerificationsByMemberId(teamAssignmentId));


        [HttpPut("approve-appeal-admin")]
        public async Task<APIResponse<AppealVerificationResponse>> AppealApprovedByAdmin() => await service.AppealApprovedByAdmin();

    }
}
