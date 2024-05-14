using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IMemberRepository: IBaseRepository<Member>
    {
        Task<IEnumerable<MemberResponse>> GetAllMembers();

        Task<IEnumerable<MemberBasicDetailsResponse>> GetAllMembersBasicDetails();

        Task<MemberResponse> GetMemberById(Guid id);

    }
}
