using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IProposalService
    {
        Task<APIResponse<ProposalResponse>> SendProposal(Guid recieverId);

        Task<APIResponse<ProposalResponse>> UpdateProposalStatus(ProposalUpdateRequest model);

        Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetSentProposals();

        Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetRecievedProposals();

        Task<APIResponse<IEnumerable<ProposalInfoResponse>>> GetAcceptedProposals();
    }
}
