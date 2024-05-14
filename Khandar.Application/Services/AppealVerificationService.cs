using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;

namespace Khandar.Application.Services
{
    public class AppealVerificationService : IAppealVerificationService
    {
        private readonly IAppealVerificationRepostory repository;
        private readonly IContextService contextService;
        private readonly IMapper mapper;

        public AppealVerificationService(IAppealVerificationRepostory repository,
            IContextService contextService,
            IMapper mapper)
        {
            this.repository = repository;
            this.contextService = contextService;
            this.mapper = mapper;
        }

        public async Task<APIResponse<AppealVerificationResponse>> AppealApproveByLeader(ApproveAppealLeaderRequest model)
        {
            var leaderId = contextService.GetUserId().Value;

            var appealVerification = mapper.Map<AppealVerification>(model);

            appealVerification.MemberId = leaderId;
           

            int returnValue = await repository.UpdateAsync(appealVerification);

            if (returnValue > 0)
                return APIResponse<AppealVerificationResponse>.SuccessResponse(mapper.Map<AppealVerificationResponse>(appealVerification), APIStatusCodes.OK);

            return APIResponse<AppealVerificationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public Task<APIResponse<AppealVerificationResponse>> AppealApprovedByAdmin()
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<AppealMemberVerificationResponse>>> GetAllVerifications(Guid teamAssignmentId)
        {
            var appealMemberVerificatios = await repository.GetAllVerifications(teamAssignmentId);

            if (appealMemberVerificatios.Any())
                return APIResponse<IEnumerable<AppealMemberVerificationResponse>>.SuccessResponse(appealMemberVerificatios, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealMemberVerificationResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<AppealMemberVerificationResponse>> GetMemberVerificationsByMemberId(Guid teamAssignmentId)
        {
            var memberId = contextService.GetUserId().Value ;
            var appealMemberVerification = await repository.GetMemberVerificationsByMemberId(teamAssignmentId, memberId);

            if (appealMemberVerification is not null )
                return APIResponse<AppealMemberVerificationResponse>.SuccessResponse(appealMemberVerification, APIStatusCodes.OK);

            return APIResponse<AppealMemberVerificationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<AppealVerificationResponse>> VerifyAppeal(AppealVerificationRequest model)
        {
            var memberId = contextService.GetUserId().Value;

            var isExist=  await repository.IsExist(x => x.MemberId == memberId && x.TeamAssignmentId == model.TeamAssignmentId);


            if(isExist)
                return APIResponse<AppealVerificationResponse>.ErrorResponse("Remarks already added ", APIStatusCodes.InternalServerError);


            var appealVerification = mapper.Map<AppealVerification>(model);
            appealVerification.MemberId = memberId;

            int returnValue = await repository.InsertAsync(appealVerification);

            if (returnValue > 0)
                return APIResponse<AppealVerificationResponse>.SuccessResponse(mapper.Map<AppealVerificationResponse>(appealVerification), APIStatusCodes.OK);

            return APIResponse<AppealVerificationResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }
    }
}
