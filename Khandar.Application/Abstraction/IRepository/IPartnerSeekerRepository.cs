using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using System.Threading.Tasks;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IPartnerSeekerRepository : IBaseRepository<PartnerSeeker>
    {
        Task<IEnumerable<PartnerSeekerPublicResponse>> GetAllAsync(Gender gender);

        Task<IEnumerable<PartnerSeekerPublicResponse>> GetAllPartnerseekersAsync();


        Task<IEnumerable<PartnerSeekerPublicResponse>> SearchPartnerSeeker(string nameTerm);

        Task<BasicProfileResponse> GetMyProfile(Guid id);

        Task<PartnerSeekerResponse> GetMyPartnerSeekerDetails(Guid id);

        Task<PersonalInfoResponse> GetPersonalInfoById(Guid id);


        Task<VisibilityLevel?> CheckVisibility(Guid senderId, Guid recieverId);

        Task<ReligiousInfoResponse> GetReligiousInfoById(Guid id);

        Task<FamilyInfoResponse> GetFamilyInfoById(Guid id);

        Task<AppearanceInfoResponse> GetAppearanceInfoById(Guid id);

        Task<ProfessionalInfoResponse> GetProfessionalInfoById(Guid id);

    }
}
