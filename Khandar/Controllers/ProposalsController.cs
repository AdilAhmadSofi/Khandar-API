using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalsController : ApiController
    {
        private readonly IProposalService service;

        public ProposalsController(IProposalService service)
        {
            this.service = service;
        }
        
        [HttpPost("send-proposal/{id:guid}")]
        public async Task<IResult> Insert(Guid id) => this.APIResult(await service.SendProposal(id));


        [HttpPut("update-proposal-status")]
        public async Task<IResult> UpdateProposalStatus(ProposalUpdateRequest model) => this.APIResult(await service.UpdateProposalStatus(model));

        
        [HttpGet("sent-proposals")]
        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> SentProposals() => await service.GetSentProposals();
 
        
        [HttpGet("recieved-proposals")]
        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> RecievedProposals() => await service.GetRecievedProposals();
        

        [HttpGet("accepted-proposals")]
        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> AcceptedProposals() => await service.GetAcceptedProposals();

    }
}
