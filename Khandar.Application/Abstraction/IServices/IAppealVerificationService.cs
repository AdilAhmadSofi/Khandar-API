using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IAppealVerificationService
    {
        Task<APIResponse<AppealVerificationResponse>> VerifyAppeal(AppealVerificationRequest model);


        Task<APIResponse<IEnumerable<AppealMemberVerificationResponse>>> GetAllVerifications(Guid teamAssignmentId);

        Task<APIResponse<AppealMemberVerificationResponse>> GetMemberVerificationsByMemberId(Guid teamAssignmentId);

        Task<APIResponse<AppealVerificationResponse>> AppealApproveByLeader(ApproveAppealLeaderRequest model);

        Task<APIResponse<AppealVerificationResponse>> AppealApprovedByAdmin();
    }
}
