using AutoMapper;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public SocialMediaService(ISocialMediaRepository repository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextService = contextService;
        }


        public async Task<APIResponse<SocialMediaResponse>> InsertAsync(SocialMediaRequest model)
        {
            var partnerSeekerId = contextService.GetUserId();


            var socialMedia = mapper.Map<SocialMediaRequest, SocialMedia>(model);
            socialMedia.PartnerSeekerId = partnerSeekerId.Value;
            socialMedia.CreatedBy = partnerSeekerId;
            socialMedia.CreatedOn = DateTimeOffset.Now;
            var returnResult = await repository.InsertAsync(socialMedia);

            if (returnResult > 0)
                return APIResponse<SocialMediaResponse>.SuccessResponse(mapper.Map<SocialMediaResponse>(socialMedia), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetAllAsync()
        {
            var partnerSeekerId = contextService.GetUserId();


            var socialMedias = await repository.FindByAsync(s => s.PartnerSeekerId == partnerSeekerId.Value);

            if (socialMedias is null)
                return APIResponse<IEnumerable<SocialMediaResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<SocialMediaResponse>>.SuccessResponse(mapper.Map<IEnumerable<SocialMediaResponse>>(socialMedias), APIStatusCodes.OK);
        }


        public async Task<APIResponse<SocialMediaResponse>> UpdateAsync(SocialMediaUpdateRequest model)
        {
            var partnerSeekerId = contextService.GetUserId();


            var socialMedia = await repository.FirstOrDefaultAsync(socialMedia => socialMedia.Id == model.Id);

            if (socialMedia is null)
                return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            var updatedSocialMedia = mapper.Map(model, socialMedia);
            updatedSocialMedia.UpdatedBy = partnerSeekerId;
            updatedSocialMedia.UpdatedOn = DateTimeOffset.Now;

            var returnResult = await repository.UpdateAsync(updatedSocialMedia);

            if (returnResult > 0)
                return APIResponse<SocialMediaResponse>.SuccessResponse(mapper.Map<SocialMediaResponse>(updatedSocialMedia), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<SocialMediaResponse>> GetByIdAsync(Guid id)
        {
            var socialMedia = await repository.GetByIdAsync(id);
            if (socialMedia is null) return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<SocialMediaResponse>.SuccessResponse(mapper.Map<SocialMediaResponse>(socialMedia), APIMessages.Success, APIStatusCodes.OK);
        }


        public async Task<APIResponse<SocialMediaResponse>> DeleteAsync(Guid id)
        {
            var partnerSeekerId = contextService.GetUserId();

            var socialMedia = await repository.GetByIdAsync(id);
            if (socialMedia is null) return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            int returnValue = await repository.DeleteAsync(socialMedia);
            if (returnValue > 0)
                return APIResponse<SocialMediaResponse>.SuccessResponse(mapper.Map<SocialMediaResponse>(socialMedia), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<SocialMediaResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }
    }
}