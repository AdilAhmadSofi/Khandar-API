using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IProposalRepository : IBaseRepository<Proposal>
    {
        Task<IEnumerable<ProposalInfoResponse>> GetSentProposals(Guid senderId);

        Task<IEnumerable<ProposalInfoResponse>> GetRecievedProposals(Guid recieverId);

        Task<IEnumerable<ProposalInfoResponse>> GetAcceptedProposals(Guid recieverId);
    }
}
