using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IAppealVerificationRepostory:IBaseRepository<AppealVerification>
    {
        Task<IEnumerable<AppealMemberVerificationResponse>> GetAllVerifications(Guid teamAssignmentId);


        Task<AppealMemberVerificationResponse> GetMemberVerificationsByMemberId(Guid teamAssignmentId, Guid memberId);

    }
}
