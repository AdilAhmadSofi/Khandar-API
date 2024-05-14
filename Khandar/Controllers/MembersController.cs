using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Khandar.Api.Controllers
{
   // [Route("api/[controller]")]
    //[ApiController]
    public class MembersController : ApiController
    {
        private readonly IMemberService service;

        public MembersController(IMemberService service)
        {
            this.service = service;
        }


        [HttpGet]
        public Task<APIResponse<IEnumerable<MemberResponse>>> GetAll() => service.GetAll();



        [HttpGet("member-basic-details")]
        public Task<APIResponse<IEnumerable<MemberBasicDetailsResponse>>> GetAllMemberBasicDetails() => service.GetAllMemberBasicDetails();


        [HttpGet("team/{id:guid}")]
        public async Task<IResult> GetAllTeamMember(Guid id) => this.APIResult(await service.GetAllByTeam(id));


        [HttpGet("member-id")]
        public async Task<IResult> GetById([FromQuery]Guid? id) => this.APIResult(await service.GetById(id));



        [HttpPut]
        public async Task<IResult> Update([FromForm]MemberRequest model) => this.APIResult(await service.Update(model));


        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id) => this.APIResult(await service.Delete(id));



        [HttpGet("approved-donation-appeals")]
        public async Task<APIResponse<IEnumerable<DonationAppealResponse>>> GetApprovedAppeals() => await service.GetApprovedAppeals();

        [HttpGet("total-member")]
        public async Task<int> GetTotalMembers() => await service.GetTotalMembers();
    }
}
