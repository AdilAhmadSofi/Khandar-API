using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    public class PartnerPreferenceService : IPartnerPreferenceService
    {
        private readonly IPartnerPrefereceRepository repository;
        private readonly IContextService contextService;
        private readonly IMapper mapper;

        public PartnerPreferenceService(IPartnerPrefereceRepository repository,
            IContextService contextService,
            IMapper mapper)
        {
            this.repository = repository;
            this.contextService = contextService;
            this.mapper = mapper;
        }
        public async Task<APIResponse<PartnerPreferenceResponse>> InsertAsync(PartnerPreferenceRequest model)
        {
            var partnerSeekerId = contextService.GetUserId().Value;
            var partnerPreference = mapper.Map<PartnerPreference>(model);
            partnerPreference.Id = partnerSeekerId;

            int returnValue = await repository.InsertAsync(partnerPreference);

            if (returnValue > 0)
                return APIResponse<PartnerPreferenceResponse>.SuccessResponse(mapper.Map<PartnerPreferenceResponse>(partnerPreference), APIStatusCodes.OK);

            return APIResponse<PartnerPreferenceResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<PartnerPreferenceResponse>> GetByIdAsync(Guid id)
        {
            var partnerPreferenceResponse = await repository.GetByIdAsync(id);
        
            if(partnerPreferenceResponse is null)
                return APIResponse<PartnerPreferenceResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
           
            return APIResponse<PartnerPreferenceResponse>.SuccessResponse(mapper.Map<PartnerPreferenceResponse>(partnerPreferenceResponse), APIStatusCodes.OK);
        }

        public Task<APIResponse<PartnerPreferenceResponse>> GetMyPreference()
        {
            throw new NotImplementedException();
        }

    }
}
