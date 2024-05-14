using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IPartnerSeekerService
    {
        #region General Calls
        Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAll();

        Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAllPartnerSeekers();


        Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> SearchPartnerSeeker(string nameTerm);

        #endregion


        #region Own Calls

        Task<APIResponse<PartnerSeekerResponse>> Update(PartnerSeekerRequest model);

        Task<APIResponse<PartnerSeekerResponse>> GetMyPartnerSeekerDetails(Guid? id);

        Task<APIResponse<BasicProfileResponse>> GetMyProfile();

        Task<APIResponse<PartnerSeekerResponse>> UpdateVisibilty(PartnerSeekerVisibiltyRequest model);

        Task<APIResponse<string>> SetProfilePictureVisibility(ProfilePictureVisibilty profilePictureVisibilty);

        Task<APIResponse<PartnerSeekerResponse>> Delete(Guid id);

        #endregion


        #region MyPartner Calls

        Task<APIResponse<PersonalInfoResponse>> GetPersonalInfoById(Guid? senderId);

        Task<APIResponse<ReligiousInfoResponse>> GetReligiousInfoById(Guid? id);

        Task<APIResponse<FamilyInfoResponse>> GetFamilyInfoById(Guid id);

        Task<APIResponse<AppearanceInfoResponse>> GetAppearanceInfoById(Guid id);

        Task<APIResponse<ProfessionalInfoResponse>> GetProfessionalInfoById(Guid id);

        Task<APIResponse<IEnumerable<QualificationResponse>>> GetQualificationsById(Guid id);

        Task<APIResponse<IEnumerable<HobbyResponse>>> GetHobbiessById(Guid id);

        Task<APIResponse<IEnumerable<AddressResponse>>> GetAddressesById(Guid id);

        Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetJobHistoriesById(Guid id);

        Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetSocialMediasById(Guid id);
        Task<int> GetTotalPartnerseekers();

        #endregion
    }
}
