using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Services;

public class PartnerSeekerService : IPartnerSeekerService
{
    private readonly IPartnerSeekerRepository repository;
    private readonly IUserRepository userRepository;
    private readonly IAppFileRepository appFileRepository;
    private readonly IMapper mapper;
    private readonly IContextService contextService;
    private readonly IFileService fileService;
    private readonly IQualificationRepository qualificationRepository;
    private readonly IJobHistoryRepository jobHistoryRepository;
    private readonly ISocialMediaRepository socialMediaRepository;
    private readonly IAddressRepository addressRepository;
    private readonly IHobbyRepository hobbyRepository;

    public PartnerSeekerService(IPartnerSeekerRepository repository,
        IUserRepository userRepository,
        IAppFileRepository appFileRepository,
        IMapper mapper, IContextService contextService,
        IFileService fileService,
        IQualificationRepository qualificationRepository,
        IJobHistoryRepository jobHistoryRepository,
        ISocialMediaRepository socialMediaRepository,
        IAddressRepository addressRepository,
        IHobbyRepository hobbyRepository
        )
    {
        this.repository = repository;
        this.userRepository = userRepository;
        this.appFileRepository = appFileRepository;
        this.mapper = mapper;
        this.contextService = contextService;
        this.fileService = fileService;
        this.qualificationRepository = qualificationRepository;
        this.jobHistoryRepository = jobHistoryRepository;
        this.socialMediaRepository = socialMediaRepository;
        this.addressRepository = addressRepository;
        this.hobbyRepository = hobbyRepository;
    }

    #region General
    public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> SearchPartnerSeeker(string nameTerm)
    {
        var personalInfoResponses = await repository.SearchPartnerSeeker(nameTerm);

        if (personalInfoResponses is not null && personalInfoResponses.Any())
            return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.SuccessResponse(mapper.Map<IEnumerable<PartnerSeekerPublicResponse>>(personalInfoResponses), $"Found {personalInfoResponses.Count()} profiles");

        return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.ErrorResponse("No Profile Found", APIStatusCodes.NoContent);
    }

    public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAll()
    {
        Gender gender = (Gender)Enum.Parse(typeof(Gender), contextService.GetGender());

        var partnerSeekers = await repository.GetAllAsync(gender);

        if (partnerSeekers is not null && partnerSeekers.Any())
            return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.SuccessResponse(mapper.Map<IEnumerable<PartnerSeekerPublicResponse>>(partnerSeekers), $"Found {partnerSeekers.Count()} profiles");

        return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.ErrorResponse("No Profile Found", APIStatusCodes.NoContent);
    }

    public async Task<APIResponse<IEnumerable<PartnerSeekerPublicResponse>>> GetAllPartnerSeekers()
    {
        Gender gender = (Gender)Enum.Parse(typeof(Gender), contextService.GetGender());

        var partnerSeekers = await repository.GetAllPartnerseekersAsync();

        if (partnerSeekers is not null && partnerSeekers.Any())
            return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.SuccessResponse(mapper.Map<IEnumerable<PartnerSeekerPublicResponse>>(partnerSeekers), $"Found {partnerSeekers.Count()} profiles");

        return APIResponse<IEnumerable<PartnerSeekerPublicResponse>>.ErrorResponse("No Profile Found", APIStatusCodes.NoContent);
    }

    #endregion


    #region Own Calls
    public async Task<APIResponse<PartnerSeekerResponse>> Update(PartnerSeekerRequest model)
    {
        var partnerSeeker = await repository.FirstOrDefaultAsync(partnerSeeker => partnerSeeker.Id == model.Id);

        if (partnerSeeker is null)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse("No Profile Found", APIStatusCodes.NotFound);

        var emailExists = await userRepository.FirstOrDefaultAsync(x => x.Email == model.Email && x.Id != model.Id) is not null;
        if (emailExists)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse("Email already exists please choose another", APIStatusCodes.Conflict);

        var contactExists = await userRepository.FirstOrDefaultAsync(x => x.ContactNo == model.ContactNo && x.Id != model.Id) is not null;
        if (contactExists)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse("Contact number already exists please choose another", APIStatusCodes.Conflict);

        var updatedPartnerSeeker = mapper.Map(model, partnerSeeker);
        var user = await userRepository.GetByIdAsync(partnerSeeker.Id);
        user!.Name = model.Name;
        user!.Email = model.Email;
        user!.ContactNo = model.ContactNo;
        user!.UpdatedBy = model.Id;
        user!.UpdatedOn = DateTimeOffset.Now;
        updatedPartnerSeeker.UpdatedBy = model.Id;
        updatedPartnerSeeker.UpdatedOn = DateTimeOffset.Now;

        if (model.File != null)
        {
            var dbAppFile = await appFileRepository.FirstOrDefaultAsync(x => x.EntityId == partnerSeeker.Id);
            if (dbAppFile != null)
            {
                string oldPath = dbAppFile.FilePath;

                dbAppFile.FilePath = await fileService.UploadFileAsync(model.File);
                dbAppFile.UpdatedOn = DateTimeOffset.Now;
                dbAppFile.UpdatedBy = model.Id;

                var returnCode = await appFileRepository.UpdateAsync(dbAppFile);
                if (returnCode > 0)
                    await fileService.DeleteFileAsync(oldPath);
            }
            else
            {
                string path = await fileService.UploadFileAsync(model.File);
                AppFile file = new()
                {
                    Module = Domain.Enums.Module.PartnerSeeker,
                    CreatedBy = contextService.GetUserId(),
                    CreatedOn = DateTimeOffset.Now,
                    EntityId = partnerSeeker.Id,
                    FilePath = path
                };

                var returnCode = await appFileRepository.InsertAsync(file);
            }
        }
        user.PartnerSeeker = updatedPartnerSeeker;
        int returnValue = await userRepository.UpdateAsync(user);
        if (returnValue > 0)
        {
            var partnerSeekerResponse = await repository.GetByIdAsync(partnerSeeker.Id);
            if (partnerSeekerResponse != null)
                return APIResponse<PartnerSeekerResponse>.SuccessResponse(mapper.Map<PartnerSeekerResponse>(partnerSeeker), "Profile Updated Successfully", APIStatusCodes.OK);
        }
        return APIResponse<PartnerSeekerResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
    }


    public async Task<APIResponse<PartnerSeekerResponse>> UpdateVisibilty(PartnerSeekerVisibiltyRequest model)
    {
        var partnerSeeker = await repository.GetByIdAsync(model.Id);

        if (partnerSeeker is null)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.NotFound);

        partnerSeeker.UpdatedOn = DateTimeOffset.Now;
        partnerSeeker.UpdatedBy = partnerSeeker.Id;
        int returnValue = await repository.UpdateAsync(partnerSeeker);
        if (returnValue > 0)
            return APIResponse<PartnerSeekerResponse>.SuccessResponse(mapper.Map<PartnerSeekerResponse>(partnerSeeker), "Profile Deleted Successfully", APIStatusCodes.OK);

        return APIResponse<PartnerSeekerResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<PartnerSeekerResponse>> GetMyPartnerSeekerDetails(Guid? id)
    {
        var partnerSeekerId = id ?? contextService.GetUserId()!.Value;
        var partnerSeeker = await repository.GetMyPartnerSeekerDetails(partnerSeekerId);

        if (partnerSeeker is null)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

        return APIResponse<PartnerSeekerResponse>.SuccessResponse(partnerSeeker, APIStatusCodes.OK);
    }

    public async Task<APIResponse<BasicProfileResponse>> GetMyProfile()
    {
        Guid id = contextService.GetUserId().Value;
        var profile = await repository.GetMyProfile(id);
        if (profile is null)
            return APIResponse<BasicProfileResponse>.ErrorResponse("Please update your full profile", APIStatusCodes.Conflict);

        return APIResponse<BasicProfileResponse>.SuccessResponse(profile, APIStatusCodes.OK);

    }

    public async Task<APIResponse<string>> SetProfilePictureVisibility(ProfilePictureVisibilty profilePictureVisibilty)
    {
        var partnerSeekerId = contextService.GetUserId();

        if (partnerSeekerId is null)
            return APIResponse<string>.ErrorResponse(APIMessages.LoginFirst, APIStatusCodes.BadRequest);

        var partnerSeeker = mapper.Map<PartnerSeeker>(
            new PartnerSeeker
            {
                Id = partnerSeekerId.Value,
                ProfilePictureVisibilty = profilePictureVisibilty,
                UpdatedBy = partnerSeekerId,
                UpdatedOn = DateTimeOffset.Now
            });
        int returnValue = await repository.UpdateAsync(partnerSeeker);

        if (returnValue > 0)
            return APIResponse<string>.SuccessResponse("Profile Visibility Set Successfully", APIStatusCodes.OK);

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<PartnerSeekerResponse>> Delete(Guid id)
    {

        var partnerSeeker = await repository.GetByIdAsync(id);

        if (partnerSeeker is null)
            return APIResponse<PartnerSeekerResponse>.ErrorResponse("No Profile Found", APIStatusCodes.NotFound);

        partnerSeeker.IsDeleted = true;
        partnerSeeker.UpdatedOn = DateTimeOffset.Now;
        partnerSeeker.UpdatedBy = partnerSeeker.Id;

        int returnValue = await repository.UpdateAsync(partnerSeeker);
        if (returnValue > 0)
            return APIResponse<PartnerSeekerResponse>.SuccessResponse(mapper.Map<PartnerSeekerResponse>(partnerSeeker), "Profile Deleted Successfully", APIStatusCodes.OK);

        return APIResponse<PartnerSeekerResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
    }

    #endregion


    #region MyPartner Calls

    public async Task<APIResponse<PersonalInfoResponse>> GetPersonalInfoById(Guid? senderId)
    {
        var recieverId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, recieverId.Value))
        {
            var personalInfoResponse = await repository.GetPersonalInfoById(senderId.Value);
            if (personalInfoResponse is null)
                return APIResponse<PersonalInfoResponse>.ErrorResponse("No  Details Found", APIStatusCodes.NoContent);

            return APIResponse<PersonalInfoResponse>.SuccessResponse(personalInfoResponse, APIStatusCodes.OK);

        }
        return APIResponse<PersonalInfoResponse>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);
    }

    public async Task<APIResponse<ReligiousInfoResponse>> GetReligiousInfoById(Guid? senderId)
    {
        var recieverId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, recieverId.Value))
        {
            var religiousInfoResponse = await repository.GetReligiousInfoById(senderId.Value);

            if (religiousInfoResponse is null)
                return APIResponse<ReligiousInfoResponse>.ErrorResponse("No Religious Details Found", APIStatusCodes.NoContent);

            return APIResponse<ReligiousInfoResponse>.SuccessResponse(religiousInfoResponse, APIStatusCodes.OK);
        }
        return APIResponse<ReligiousInfoResponse>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);
    }

    public async Task<APIResponse<FamilyInfoResponse>> GetFamilyInfoById(Guid senderId)
    {
        var recieverId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId, recieverId.Value))
        {
            var familyInfoResponse = await repository.GetFamilyInfoById(senderId);

            if (familyInfoResponse is null)
                return APIResponse<FamilyInfoResponse>.ErrorResponse("No family details found", APIStatusCodes.NoContent);

            return APIResponse<FamilyInfoResponse>.SuccessResponse(familyInfoResponse, APIStatusCodes.OK);
        }
        return APIResponse<FamilyInfoResponse>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);

    }

    public async Task<APIResponse<AppearanceInfoResponse>> GetAppearanceInfoById(Guid senderId)
    {
        var recieverId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId, recieverId.Value))
        {
            var appearanceInfoResponse = await repository.GetAppearanceInfoById(senderId);

            if (appearanceInfoResponse is null)
                return APIResponse<AppearanceInfoResponse>.ErrorResponse("No Appearance details found", APIStatusCodes.NoContent);

            return APIResponse<AppearanceInfoResponse>.SuccessResponse(appearanceInfoResponse, APIStatusCodes.OK);
        }
        return APIResponse<AppearanceInfoResponse>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);
    }

    public async Task<APIResponse<ProfessionalInfoResponse>> GetProfessionalInfoById(Guid senderId)
    {
        var recieverId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId, recieverId.Value))
        {
            var professionalInfoResponse = await repository.GetProfessionalInfoById(senderId);

            if (professionalInfoResponse is null)
                return APIResponse<ProfessionalInfoResponse>.ErrorResponse("No Appear details found", APIStatusCodes.NoContent);

            return APIResponse<ProfessionalInfoResponse>.SuccessResponse(professionalInfoResponse, APIStatusCodes.OK);
        }
        return APIResponse<ProfessionalInfoResponse>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);
    }

    public async Task<APIResponse<IEnumerable<QualificationResponse>>> GetQualificationsById(Guid id)
    {
        var senderId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, id))
        {
            var qualificationResponses = await qualificationRepository.GetQualificationById(id);

            if (qualificationResponses is null)
                return APIResponse<IEnumerable<QualificationResponse>>.ErrorResponse("No Qualification details found", APIStatusCodes.NoContent);

            return APIResponse<IEnumerable<QualificationResponse>>.SuccessResponse(qualificationResponses, APIStatusCodes.OK);
        }
        return APIResponse<IEnumerable<QualificationResponse>>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);
    }

    public async Task<APIResponse<IEnumerable<HobbyResponse>>> GetHobbiessById(Guid id)
    {
        var senderId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, id))
        {
            var hobbyResponses = await hobbyRepository.GetHobbiesById(id);

            if (hobbyResponses is null)
                return APIResponse<IEnumerable<HobbyResponse>>.ErrorResponse("No Qualification details found", APIStatusCodes.NoContent);

            return APIResponse<IEnumerable<HobbyResponse>>.SuccessResponse(hobbyResponses, APIStatusCodes.OK);
        }
        return APIResponse<IEnumerable<HobbyResponse>>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);

    }

    public async Task<APIResponse<IEnumerable<AddressResponse>>> GetAddressesById(Guid id)
    {
        var senderId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, id))
        {
            var addressResponses = await addressRepository.GetAddressesById(id);

            if (addressResponses is null)
                return APIResponse<IEnumerable<AddressResponse>>.ErrorResponse("No Address details found", APIStatusCodes.NoContent);

            return APIResponse<IEnumerable<AddressResponse>>.SuccessResponse(addressResponses, APIStatusCodes.OK);
        }
        return APIResponse<IEnumerable<AddressResponse>>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);

    }

    public async Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetJobHistoriesById(Guid id)
    {
        var senderId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, id))
        {
            var jobHistoryResponses = await jobHistoryRepository.GetJobHistoriesById(id);

            if (jobHistoryResponses is null)
                return APIResponse<IEnumerable<JobHistoryResponse>>.ErrorResponse("No Qualification details found", APIStatusCodes.NoContent);

            return APIResponse<IEnumerable<JobHistoryResponse>>.SuccessResponse(jobHistoryResponses, APIStatusCodes.OK);
        }
        return APIResponse<IEnumerable<JobHistoryResponse>>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);

    }

    public async Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetSocialMediasById(Guid id)
    {
        var senderId = contextService.GetUserId();

        if (await GetVisibilityLevel(senderId.Value, id))
        {
            var socialMediaResponses = await socialMediaRepository.GetSocialMediasById(id);

            if (socialMediaResponses is null)
                return APIResponse<IEnumerable<SocialMediaResponse>>.ErrorResponse("No Social Media handles found", APIStatusCodes.NoContent);

            return APIResponse<IEnumerable<SocialMediaResponse>>.SuccessResponse(socialMediaResponses, APIStatusCodes.OK);
        }
        return APIResponse<IEnumerable<SocialMediaResponse>>.ErrorResponse("You are not permisible to visit the profile", APIStatusCodes.BadRequest);

    }

    #endregion






    private async Task<bool> GetVisibilityLevel(Guid senderId, Guid recieverId)
    {
        var visibilityLevel = await repository.CheckVisibility(senderId, recieverId);
        return visibilityLevel == null ? false : true;
        //return visibilityLevel == VisibilityLevel.Level2;
    }

    public async Task<int> GetTotalPartnerseekers()
    {
        var res = await repository.GetAllAsync();

        if(res.Any())
            return res.Count();

        return 0;
    }
}