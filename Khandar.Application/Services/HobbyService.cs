using AutoMapper;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    internal class HobbyService : IHobbyService
    {
        private readonly IHobbyRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public HobbyService(IHobbyRepository repository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextService = contextService;
        }


        public async Task<APIResponse<HobbyResponse>> Insert(HobbyRequest model)
        {
            var partnerSeekerId = contextService.GetUserId().Value;


            var hobby = mapper.Map<Hobby>(model);
            hobby.CreatedBy = partnerSeekerId;
            hobby.CreatedOn = DateTimeOffset.Now;
            hobby.PartnerSeekerId = partnerSeekerId;
            var returnResult = await repository.InsertAsync(hobby);

            if (returnResult > 0)
                return APIResponse<HobbyResponse>.SuccessResponse(mapper.Map<HobbyResponse>(hobby), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<HobbyResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<IEnumerable<HobbyResponse>>> GetAllAsync()
        {
            var partnerSeekerId = contextService.GetUserId();

            var hobbies = await repository.FindByAsync(p => p.PartnerSeekerId == partnerSeekerId);

            if (hobbies is null)
                return APIResponse<IEnumerable<HobbyResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<HobbyResponse>>.SuccessResponse(mapper.Map<IEnumerable<HobbyResponse>>(hobbies), APIStatusCodes.OK);

        }

        public async Task<APIResponse<HobbyResponse>> Delete(Guid id)
        {
            var partnerSeekerId = contextService.GetUserId();


            var hobby = await repository.GetByIdAsync(id);
            if (hobby is null) return APIResponse<HobbyResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            int returnValue = await repository.DeleteAsync(hobby);
            if (returnValue > 0)
                return APIResponse<HobbyResponse>.SuccessResponse(mapper.Map<HobbyResponse>(hobby), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<HobbyResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }
    }
}
