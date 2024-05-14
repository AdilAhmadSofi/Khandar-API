using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;

        public QualificationService(IQualificationRepository repository, IMapper mapper, IContextService contextService)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextService = contextService;
        }
        public async Task<APIResponse<QualificationResponse>> InsertAsync(QualificationRequest model)
        {
            var partnerSeekerId = contextService.GetUserId();



            var qualification = mapper.Map<Qualification>(model);
            qualification.CreatedBy = partnerSeekerId.Value;
            qualification.CreatedOn = DateTimeOffset.Now;
            qualification.PartnerSeekerId = partnerSeekerId.Value;

            var returnResult = await repository.InsertAsync(qualification);

            if (returnResult > 0)
                return APIResponse<QualificationResponse>.SuccessResponse(mapper.Map<QualificationResponse>(qualification), APIMessages.Success, APIStatusCodes.OK);

            return APIResponse<QualificationResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }


        public async Task<APIResponse<IEnumerable<QualificationResponse>>> GetMyQualifications()
        {
            var partnerSeekerId = contextService.GetUserId();


            var qualifications = await repository.FindByAsync(q => q.PartnerSeekerId == partnerSeekerId);

            if (qualifications is null)
                return APIResponse<IEnumerable<QualificationResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<QualificationResponse>>.SuccessResponse(mapper.Map<IEnumerable<QualificationResponse>>(qualifications), APIStatusCodes.OK);

        }


        public async Task<APIResponse<QualificationResponse>> GetByIdAsync(Guid id)
        {
            var qualification = await repository.GetByIdAsync(id);

            if (qualification is null)
                return APIResponse<QualificationResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<QualificationResponse>.SuccessResponse(mapper.Map<QualificationResponse>(qualification), APIMessages.Success, APIStatusCodes.OK);
        }


        public async Task<APIResponse<QualificationResponse>> DeleteAsync(Guid id)
        {
            var partnerSeekerId = contextService.GetUserId();


            var qualification = await repository.GetByIdAsync(id);
            if (qualification is null) return APIResponse<QualificationResponse>.ErrorResponse("Qualification not found", APIStatusCodes.NotFound);

            int returnValue = await repository.DeleteAsync(qualification);

            if (returnValue > 0)
                return APIResponse<QualificationResponse>.SuccessResponse(mapper.Map<QualificationResponse>(qualification), APIStatusCodes.OK);

            return APIResponse<QualificationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }
    }
}
