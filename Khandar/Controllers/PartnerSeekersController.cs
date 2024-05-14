using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerSeekersController : ApiController
    {
        private readonly IPartnerSeekerService service;

        public PartnerSeekersController(IPartnerSeekerService service)
        {
            this.service = service;
        }

        #region General Calls
        [HttpGet]
        public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAll() => await service.GetAll(); 
        
        [HttpGet("all-partnerseekers")]
        public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAllPartnerSeekers() => await service.GetAllPartnerSeekers();



        [HttpGet("search")]

        public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> SearchPartnerSeeker(string nameTerm) => await service.SearchPartnerSeeker(nameTerm);


        #endregion


        #region My Own Calls

        [HttpGet("my-details")]
        public async Task<APIResponse<PartnerSeekerResponse>> GetMyPartnerSeekerDetails([FromQuery] Guid? id) => await service.GetMyPartnerSeekerDetails(id);


        [HttpGet("profile")]
        public async Task<APIResponse<BasicProfileResponse>> MyProfile() => await service.GetMyProfile();


        [HttpDelete]
        public async Task<IResult> Delete(Guid id) => this.APIResult(await service.Delete(id));


        [HttpPut]
        public async Task<IResult> Update([FromForm] PartnerSeekerRequest model) => this.APIResult(await service.Update(model));


        [HttpPut("update-visibilty")]
        public async Task<IResult> UpdateVisibilty(PartnerSeekerVisibiltyRequest model) => this.APIResult(await service.UpdateVisibilty(model));


        [HttpPut("profile-pic-visibility")]
        public async Task<APIResponse<string>> SetProfilePictureVisibility(ProfilePictureVisibilty profilePictureVisibilty) => await service.SetProfilePictureVisibility(profilePictureVisibilty);

        #endregion


        #region MyPartner Calls


        [HttpGet("personal-info/{id:guid}")]
        public async Task<APIResponse<PersonalInfoResponse>> GetIPersonalInfoById( Guid? id) => await service.GetPersonalInfoById(id);


        [HttpGet("religious/{id:guid}")]
        public async Task<IResult> GetReligiousInfoById(Guid id) => this.APIResult(await service.GetReligiousInfoById(id));


        [HttpGet("family/{id:guid}")]
        public async Task<IResult> GetFamilyInfoById(Guid id) => this.APIResult(await service.GetFamilyInfoById(id));



        [HttpGet("appearance/{id:guid}")]
        public async Task<IResult> GetAppearanceInfoById(Guid id) => this.APIResult(await service.GetAppearanceInfoById(id));



        [HttpGet("professional/{id:guid}")]
        public async Task<IResult> GetProfessionalInfoById(Guid id) => this.APIResult(await service.GetProfessionalInfoById(id));



        [HttpGet("qualifications/{id:guid}")]
        public async Task<APIResponse<IEnumerable<QualificationResponse>>> GetQualificationsById(Guid id) => await service.GetQualificationsById(id);


        [HttpGet("hobbies/{id:guid}")]
        public async Task<APIResponse<IEnumerable<HobbyResponse>>> GetHobbiessById(Guid id) => await service.GetHobbiessById(id);


        [HttpGet("addresses/{id:guid}")]
        public async Task<APIResponse<IEnumerable<AddressResponse>>> GetAddressesById(Guid id) => await service.GetAddressesById(id);


        [HttpGet("job-histories/{id:guid}")]
        public async Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetJobHistoriesById(Guid id) => await service.GetJobHistoriesById(id);


        [HttpGet("socialmedias/{id:guid}")]
        public async Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetSocialMediasById(Guid id) => await service.GetSocialMediasById(id);


        [HttpGet("total-partnerseekers")]
        public async Task<int> GetTotalPartnerseekers() => await service.GetTotalPartnerseekers();

        #endregion

    }
}
