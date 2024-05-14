using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Khandar.Application.Services
{
    public class MemberService : IMemberService
    {
       
        private readonly IMemberRepository repository;
        private readonly IUserRepository userRepository;
        private readonly IDonationRepository donationRepository;
        private readonly IDonationAppealRepository donationAppealRepository;
        private readonly IContextService contextService;
        private readonly IFileService fileService;
        private readonly IAppFileRepository appFileRepository;
        private readonly IMapper mapper;
        private readonly ITeamMemberRepository teamMemberRepository;

        public MemberService(IMemberRepository Repository,IUserRepository userRepository,IDonationRepository donationRepository,IDonationAppealRepository donationAppealRepository,
                IContextService contextService,IFileService fileService, IAppFileRepository appFileRepository, IMapper mapper, ITeamMemberRepository teamMemberRepository)
        {
            repository = Repository;
            this.userRepository = userRepository;
            this.donationRepository = donationRepository;
            this.donationAppealRepository = donationAppealRepository;
            this.contextService = contextService;
            this.fileService = fileService;
            this.appFileRepository = appFileRepository;
            this.mapper = mapper;
            this.teamMemberRepository = teamMemberRepository;
        }


        public async Task<APIResponse<MemberResponse>> Update(MemberRequest model)
        {
            model.Id = model.Id ?? contextService.GetUserId();
            var member = await repository.FirstOrDefaultAsync(member => member.Id == model.Id);

            if (member is null)
                return APIResponse<MemberResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            var updatedMember = mapper.Map(model, member);
            var user = await userRepository.GetByIdAsync(member.Id);
            user!.Email = model.Email;
            user!.ContactNo = model.ContactNo;
            user!.Gender = model.Gender;
            user!.UpdatedOn = DateTimeOffset.Now;
            user!.UpdatedBy = model.Id;

            if (model.File != null)
            {
                var dbAppFile = await appFileRepository.FirstOrDefaultAsync(x => x.EntityId == member.Id);
                if (dbAppFile != null)
                {
                    string oldPath = dbAppFile.FilePath;

                    dbAppFile.FilePath = await fileService.UploadFileAsync(model.File);
                    dbAppFile.UpdatedOn = DateTimeOffset.Now;
                    dbAppFile.UpdatedBy= model.Id;

                    var returnCode = await appFileRepository.UpdateAsync(dbAppFile);
                    if (returnCode > 0)
                        await fileService.DeleteFileAsync(oldPath);
                }
                else
                {
                    string path = await fileService.UploadFileAsync(model.File);
                    AppFile file = new()
                    {
                        Module = Domain.Enums.Module.Member,
                        CreatedBy = contextService.GetUserId(),
                        CreatedOn = DateTimeOffset.Now,
                        EntityId = member.Id,
                        FilePath = path
                    };

                    var returnCode = await appFileRepository.InsertAsync(file);
                }
            }
            int returnValue = await repository.UpdateAsync(updatedMember);
            if (returnValue > 0)
            {
                var partnerSeekerResponse = await repository.GetByIdAsync(member.Id);
                if (partnerSeekerResponse != null)
                    return APIResponse<MemberResponse>.SuccessResponse(mapper.Map<MemberResponse>(member), "Member Profile Updated Successfully", APIStatusCodes.OK);
            }
            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);

        }

        public async Task<APIResponse<MemberResponse>> Delete(Guid id)
        {

            var member = await repository.GetByIdAsync(id);

            if (member is null)
                return APIResponse<MemberResponse>.ErrorResponse("No Member Profile Found", APIStatusCodes.NotFound);

            member.IsDeleted = true;
            member.UpdatedOn= DateTimeOffset.Now;
            member.UpdatedBy = member.Id;

            int returnValue = await repository.UpdateAsync(member);
            if (returnValue > 0)
                return APIResponse<MemberResponse>.SuccessResponse(mapper.Map<MemberResponse>(member), "Member  deleted successfully", APIStatusCodes.OK);

            return APIResponse<MemberResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<MemberResponse>> GetById(Guid? id)
        {
            var userId = id ?? contextService.GetUserId().Value;
            var member = await repository.GetMemberById(userId);

            if (member is null)
                return APIResponse<MemberResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<MemberResponse>.SuccessResponse(member, APIStatusCodes.OK);

        }

        public async Task<APIResponse<IEnumerable<MemberResponse>>> GetAllByTeam(Guid teamId)
        {
            var members = await teamMemberRepository.FindByAsync(x => x.TeamId == teamId);
            var res = members.ToList();
            if (members is not null)
                return APIResponse<IEnumerable<MemberResponse>>.SuccessResponse(mapper.Map<IEnumerable<MemberResponse>>(members), "All Member Profiles");

            return APIResponse<IEnumerable<MemberResponse>>.ErrorResponse("No Team Found", APIStatusCodes.NoContent);
        }

        public async Task<APIResponse<IEnumerable<DonationAppealResponse>>> GetApprovedAppeals()
        {
            var donationAppeals = await donationAppealRepository.FindByAsync(app => app.DonationAppealStatus == DonationAppealStatus.Approved);

            if(donationAppeals is null)
                return APIResponse<IEnumerable<DonationAppealResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<DonationAppealResponse>>.SuccessResponse(mapper.Map<IEnumerable<DonationAppealResponse>>(donationAppeals), APIStatusCodes.OK);
        }



        #region Admin Calls

        public async Task<APIResponse<IEnumerable<MemberResponse>>> GetAll()
        {
            var members = await repository.GetAllMembers();

            if (members is not null)
                return APIResponse<IEnumerable<MemberResponse>>.SuccessResponse(mapper.Map<IEnumerable<MemberResponse>>(members), "All Member Profiles");

            return APIResponse<IEnumerable<MemberResponse>>.ErrorResponse("No Profile Found", APIStatusCodes.NoContent);
        }


        public async Task<APIResponse<IEnumerable<MemberBasicDetailsResponse>>> GetAllMemberBasicDetails()
        {
            var members = await repository.GetAllMembersBasicDetails();

            if (members is not null)
                return APIResponse<IEnumerable<MemberBasicDetailsResponse>>.SuccessResponse(mapper.Map<IEnumerable<MemberBasicDetailsResponse>>(members), "All Member Profiles");

            return APIResponse<IEnumerable<MemberBasicDetailsResponse>>.ErrorResponse("No Member Found", APIStatusCodes.NoContent);
        }

        public async Task<int> GetTotalMembers()
        {
            return (await repository.GetAllAsync()).Count();
        }

        #endregion
    }
}
