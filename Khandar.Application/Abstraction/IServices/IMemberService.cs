using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IMemberService
    {
        Task<APIResponse<IEnumerable<MemberResponse>>> GetAll();

        Task<APIResponse<IEnumerable<MemberBasicDetailsResponse>>> GetAllMemberBasicDetails();

        Task<APIResponse<IEnumerable<MemberResponse>>> GetAllByTeam(Guid teamId);

        Task<APIResponse<MemberResponse>> Update(MemberRequest model);

        Task<APIResponse<MemberResponse>> GetById(Guid? id);

        Task<APIResponse<MemberResponse>> Delete(Guid id);
        
        Task<APIResponse<IEnumerable<DonationAppealResponse>>> GetApprovedAppeals();
        Task<int> GetTotalMembers();
    }
}
