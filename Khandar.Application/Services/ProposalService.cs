using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository repository;
        private readonly IContextService contextService;
        private readonly IMapper mapper;

        public ProposalService(IProposalRepository repository, IContextService contextService, IMapper mapper)
        {
            this.repository = repository;
            this.contextService = contextService;
            this.mapper = mapper;
        }

        public async Task<APIResponse<ProposalResponse>> SendProposal(Guid recieverId)
        {
            var senderId = contextService.GetUserId();

            var checkProposal = await repository.FirstOrDefaultAsync(prop => (prop.SenderId == senderId && prop.RecieverId == recieverId) || (prop.SenderId == recieverId && prop.RecieverId == senderId));
            if (checkProposal is not null)
                return APIResponse<ProposalResponse>.ErrorResponse("Already Proposed", APIStatusCodes.BadRequest);


            var proposal = new Proposal
            {
                RecieverId = recieverId,
                SenderId = senderId,
                CreatedBy = senderId,
            };

            int returnResult = await repository.InsertAsync(proposal);

            if (returnResult > 0)
                return APIResponse<ProposalResponse>.SuccessResponse(mapper.Map<ProposalResponse>(proposal), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<ProposalResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<ProposalResponse>> UpdateProposalStatus(ProposalUpdateRequest model)
        {
            var recieverId = contextService.GetUserId();

          
            var proposal = await repository.GetByIdAsync(model.Id);

            if (proposal is null)
                return APIResponse<ProposalResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            //  var updatedProposal = mapper.Map(model, proposal);
            proposal.AllowChat = model.AllowChat;
            proposal.ProposalStatus = model.ProposalStatus;

            if (model.ProposalStatus == ProposalStatus.Accepted)
                proposal.VisibilityLevel = VisibilityLevel.Level2;

            proposal.VisibilityLevel = VisibilityLevel.Level1;
            proposal.UpdatedOn = DateTimeOffset.Now;
            proposal.UpdatedBy = contextService.GetUserId();

            int returnValue = await repository.UpdateAsync(proposal);

            if (returnValue > 0)
                return APIResponse<ProposalResponse>.SuccessResponse(mapper.Map<ProposalResponse>(proposal), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<ProposalResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetRecievedProposals()
        {
            var recieverId = contextService.GetUserId();


            var sentProposals = await repository.GetRecievedProposals(recieverId.Value);

            if (sentProposals is null)
                return APIResponse<IEnumerable<ProposalInfoResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<ProposalInfoResponse>>.SuccessResponse(mapper.Map<IEnumerable<ProposalInfoResponse>>(sentProposals), $"Found {sentProposals.Count()} Proposals", APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetSentProposals()
        {
            var senderId = contextService.GetUserId();


            var recievedProposals = await repository.GetSentProposals(senderId.Value);

            if (recievedProposals is null)
                return APIResponse<IEnumerable<ProposalInfoResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<ProposalInfoResponse>>.SuccessResponse(mapper.Map<IEnumerable<ProposalInfoResponse>>(recievedProposals), $"Found {recievedProposals.Count()} Proposals", APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetAcceptedProposals()
        {
            var senderId = contextService.GetUserId();

          
            var acceptedProposals = await repository.GetAcceptedProposals(senderId.Value);

            if (acceptedProposals.Any())
                return APIResponse<IEnumerable<ProposalInfoResponse>>.SuccessResponse(mapper.Map<IEnumerable<ProposalInfoResponse>>(acceptedProposals), $"Found {acceptedProposals.Count()} Proposals", APIStatusCodes.OK);

            return APIResponse<IEnumerable<ProposalInfoResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
        }
    }
}


