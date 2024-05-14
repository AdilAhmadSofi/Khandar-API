using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    public class JobHistoryService : IJobHistoryService
    {
        private readonly IJobHistoryRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public JobHistoryService(IJobHistoryRepository repository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextService = contextService;
        }


        public async Task<APIResponse<JobHistoryResponse>> InsertAsync(JobHistoryRequest model)
        {
            var partnerSeekerId = contextService.GetUserId();

            var jobHistory = mapper.Map<JobHistory>(model);
            jobHistory.PartnerSeekerId = partnerSeekerId.Value;
            jobHistory.CreatedBy = partnerSeekerId.Value;
            jobHistory.CreatedOn = DateTimeOffset.Now;

            var returnResult = await repository.InsertAsync(jobHistory);

            if (returnResult > 0)
                return APIResponse<JobHistoryResponse>.SuccessResponse(mapper.Map<JobHistoryResponse>(jobHistory), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<JobHistoryResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetAllAsync()
        {
            var partnerSeekerId = contextService.GetUserId();


            var jobHistories = await repository.FindByAsync(p => p.PartnerSeekerId == partnerSeekerId.Value);

            if (jobHistories is null)
                return APIResponse<IEnumerable<JobHistoryResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<JobHistoryResponse>>.SuccessResponse(mapper.Map<IEnumerable<JobHistoryResponse>>(jobHistories), APIStatusCodes.OK);


        }

        public async Task<APIResponse<JobHistoryResponse>> GetByIdAsync(Guid id)
        {
            var jobHistory = await repository.GetByIdAsync(id);

            if (jobHistory is null)
                return APIResponse<JobHistoryResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<JobHistoryResponse>.SuccessResponse(mapper.Map<JobHistoryResponse>(jobHistory), APIMessages.Success, APIStatusCodes.OK);
        }


        public async Task<APIResponse<JobHistoryResponse>> DeleteAsync(Guid id)
        {

            var jobHistory = await repository.GetByIdAsync(id);
            if (jobHistory is null) return APIResponse<JobHistoryResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            int returnValue = await repository.DeleteAsync(jobHistory);

            if (returnValue > 0)
                return APIResponse<JobHistoryResponse>.SuccessResponse(mapper.Map<JobHistoryResponse>(jobHistory), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<JobHistoryResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }
    }
}
