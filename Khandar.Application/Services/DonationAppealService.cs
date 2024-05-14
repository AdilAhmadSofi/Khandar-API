using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using System.IO.Compression;

namespace Khandar.Application.Services
{
    public class DonationAppealService : IDonationAppealService
    {
        private readonly IDonationAppealRepository repository;
        private readonly ITeamAssignmentService teamAssignmentService;
        private readonly IFileService fileService;
        private readonly IAppFileRepository appFileRepository;
        private readonly IContextService contextService;
        private readonly IMapper mapper;
        private readonly IPartnerSeekerRepository partnerSeekerRepository;
        private readonly IAddressRepository addressRepository;

        public DonationAppealService(IDonationAppealRepository repository, ITeamAssignmentService teamAssignmentService, IFileService fileService,
            IAppFileRepository appFileRepository, IContextService contextService, IMapper mapper, IPartnerSeekerRepository partnerSeekerRepository, IAddressRepository addressRepository)
        {
            this.repository = repository;
            this.teamAssignmentService = teamAssignmentService;
            this.fileService = fileService;
            this.appFileRepository = appFileRepository;
            this.contextService = contextService;
            this.mapper = mapper;
            this.partnerSeekerRepository = partnerSeekerRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<APIResponse<DonationAppealResponse>> InsertAsync(DonationAppealRequest model)
        {
            var partnerSeekerId = contextService.GetUserId().Value;

            var partnerSeekerExist = await partnerSeekerRepository.IsExist(x => x.Parentage == "" && x.AnnualIncome == 0 && x.Id == partnerSeekerId);
            if (partnerSeekerExist)
                return APIResponse<DonationAppealResponse>.ErrorResponse("Please Enter Your Basic Information including Your  Annual income", APIStatusCodes.Conflict);

            var addressExist = await addressRepository.FirstOrDefaultAsync(x => x.EntityId == partnerSeekerId);
            if (addressExist is null)
                return APIResponse<DonationAppealResponse>.ErrorResponse("Please Specify Your Address", APIStatusCodes.Conflict);


            var donationAppeal = mapper.Map<DonationAppeal>(model);
            donationAppeal.BeneficiaryId = partnerSeekerId;
            donationAppeal.DonationAppealStatus = DonationAppealStatus.Pending;
            donationAppeal.CaseNo = "C-" + new Random().Next(100, 99999);

            var isExist = await repository.IsExist(x => x.BeneficiaryId == partnerSeekerId && (x.DonationAppealStatus != DonationAppealStatus.Cancelled && x.DonationAppealStatus != DonationAppealStatus.Rejected));

            if (isExist)
                return APIResponse<DonationAppealResponse>.ErrorResponse("Donation appeal is already made", APIStatusCodes.Conflict);

            string path = "";

            if (model.File != null)
            {
                path = await fileService.UploadFileAsync(model.File);
                AppFile file = new()
                {
                    Module = Domain.Enums.Module.Donation,
                    CreatedBy = contextService.GetUserId(),
                    EntityId = donationAppeal.Id,
                    FilePath = path
                };
                if (model.File.ContentType.StartsWith("video"))
                {
                    file.IsVideo = true;
                }
                var returnCode = await appFileRepository.InsertAsync(file);
            }

            int returnValue = await repository.InsertAsync(donationAppeal);
            if (returnValue > 0)
            {
                var response = mapper.Map<DonationAppealResponse>(donationAppeal);
                response.FilePath = path;
                return APIResponse<DonationAppealResponse>.SuccessResponse(response, "Your appeal for donation request is added successfully", APIStatusCodes.OK);

            }

            return APIResponse<DonationAppealResponse>.ErrorResponse(APIMessages.Error, APIStatusCodes.InternalServerError);
        }

        #region Admin Calls


        #endregion


        public async Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetTeamAppeals(Guid teamId)
        {
            var teamAppeals = await repository.GetTeamAppeals(teamId);

            if (teamAppeals.Any())
                return APIResponse<IEnumerable<DonationAppealByTeamResponse>>.SuccessResponse(mapper.Map<IEnumerable<DonationAppealByTeamResponse>>(teamAppeals), APIStatusCodes.OK);

            return APIResponse<IEnumerable<DonationAppealByTeamResponse>>.ErrorResponse("No Donation Appeals Assigned to Your team", APIStatusCodes.NotFound);

        }

        //public async Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetAppealsForTeamLeader(Guid teamId)
        //{
        //    var leaderAppeals = await repository.GetAppealsForTeamLeader(teamId);

        //    if (leaderAppeals.Any())
        //        return APIResponse<IEnumerable<DonationAppealByTeamResponse>>.SuccessResponse(mapper.Map<IEnumerable<DonationAppealByTeamResponse>>(leaderAppeals), APIStatusCodes.OK);

        //    return APIResponse<IEnumerable<DonationAppealByTeamResponse>>.ErrorResponse("No Donation Appeals Assigned to Your team", APIStatusCodes.NotFound);

        //}

        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllAppeals()
        {
            var donationAppeals = await repository.GetAllAppeals();

            if (donationAppeals.Any())
                return APIResponse<IEnumerable<AppealResponse>>.SuccessResponse(donationAppeals, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);

        }

        public async Task<APIResponse<AppealResponse>> UpdateAppealStatus(UpdateAppealStatusRequest model)
        {
            var appeal = await repository.GetByIdAsync(model.AppealId);

            if (appeal is null)
                return APIResponse<AppealResponse>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);


            var caseClosed = appeal.DonationAppealStatus == DonationAppealStatus.Completed;
            //var caseClosed= await repository.IsExist(x=>x.Id ==  model.AppealId && x.DonationAppealStatus == DonationAppealStatus.Completed);

            if (caseClosed)
                return APIResponse<AppealResponse>.ErrorResponse("You cannot update the status, Because Case is closed", APIStatusCodes.BadRequest);


            if (model.DonationAppealStatus == DonationAppealStatus.Cancelled)
            {
                var caseAlreadyApprovedOrCompleted = appeal.DonationAppealStatus == DonationAppealStatus.Completed;
                if (caseAlreadyApprovedOrCompleted)
                    return APIResponse<AppealResponse>.ErrorResponse("You cannot Cancel Because case is already approved or completed", APIStatusCodes.BadRequest);
            }


            appeal.DonationAppealStatus = model.DonationAppealStatus;
            appeal.UpdatedOn = DateTimeOffset.Now;

            int returnValue = await repository.UpdateAsync(appeal);

            if (returnValue > 0)
            {
                var appealResponse = await repository.GetAppealById(model.AppealId);
                return APIResponse<AppealResponse>.SuccessResponse(appealResponse, APIStatusCodes.OK);
            }

            return APIResponse<AppealResponse>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<IEnumerable<DonationAppealResponse>>> GetMyAppeal()
        {
            var userId = contextService.GetUserId().Value;

            var appeal = await repository.GetMyAppeal(userId);

            if (appeal is null)
                return APIResponse<IEnumerable<DonationAppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<DonationAppealResponse>>.SuccessResponse(appeal, APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<DonationAppealResponse>>> UpdateAppeal(UpdateAppealRequest model)
        {
            var appeal = await repository.GetByIdAsync(model.AppealId);


            if (appeal is null)
                return APIResponse<IEnumerable<DonationAppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);

            if (appeal.DonationAppealStatus != Domain.Enums.DonationAppealStatus.Pending)
                return APIResponse<IEnumerable<DonationAppealResponse>>.ErrorResponse("You Cannot Update Your Appeal Is Already in process", APIStatusCodes.NotFound);


            appeal.UpdatedOn = DateTimeOffset.Now;
            appeal.UpdatedBy = appeal.BeneficiaryId;
            appeal.Amount = model.Amount;
            appeal.Description = model.Description;
            appeal.IsPublic = model.IsPublic;

            if (model.File != null)
            {
                var dbAppFile = await appFileRepository.FirstOrDefaultAsync(x => x.EntityId == appeal.Id);
                if (dbAppFile != null)
                {
                    string oldPath = dbAppFile.FilePath;

                    dbAppFile.FilePath = await fileService.UploadFileAsync(model.File);
                    dbAppFile.UpdatedOn = DateTimeOffset.Now;
                    dbAppFile.UpdatedBy = appeal.BeneficiaryId;

                    if (model.File.ContentType.StartsWith("video"))
                    {
                        dbAppFile.IsVideo = true;
                    }
                    var returnCode = await appFileRepository.UpdateAsync(dbAppFile);
                    if (returnCode > 0)
                        await fileService.DeleteFileAsync(oldPath);
                }
                else
                {
                    string path = await fileService.UploadFileAsync(model.File);
                    AppFile file = new()
                    {
                        Module = Module.PartnerSeeker,
                        CreatedBy = contextService.GetUserId(),
                        CreatedOn = DateTimeOffset.Now,
                        EntityId = appeal.Id,
                        FilePath = path
                    };
                    if (model.File.ContentType.StartsWith("video"))
                    {
                        file.IsVideo = true;
                    }
                    var returnCode = await appFileRepository.InsertAsync(file);
                }
            }

            int returnValue = await repository.UpdateAsync(appeal);

            if (returnValue > 0)
            {
                var appealResponse = await repository.GetMyAppeal(appeal.BeneficiaryId);
                return APIResponse<IEnumerable<DonationAppealResponse>>.SuccessResponse(appealResponse, APIStatusCodes.OK);
            }

            return APIResponse<IEnumerable<DonationAppealResponse>>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<BeneficiaryDetailsResponse>> GetBeneficiaryDetails(Guid id)
        {
            var beneficiary = await repository.GetBeneficiaryDetails(id);

            if (beneficiary is null)
                return APIResponse<BeneficiaryDetailsResponse>.ErrorResponse("No Beneficiary Found", APIStatusCodes.NotFound);

            return APIResponse<BeneficiaryDetailsResponse>.SuccessResponse(beneficiary, APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllTeamAppeals(Guid teamId)
        {
            var donationAppeals = await repository.GetAllTeamAppeals(teamId);

            if (donationAppeals.Any())
                return APIResponse<IEnumerable<AppealResponse>>.SuccessResponse(donationAppeals, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllApprovedAppeals()
        {
            var donationAppeals = await repository.GetAllApprovedAppeals();

            if (donationAppeals.Any())
                return APIResponse<IEnumerable<AppealResponse>>.SuccessResponse(donationAppeals, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllAppealsByStatus(DonationAppealStatus appealStatus)
        {
            var donationAppeals = await repository.GetAllAppealsByStatus(appealStatus);

            if (donationAppeals?.Count() > 0)
                return APIResponse<IEnumerable<AppealResponse>>.SuccessResponse(donationAppeals, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);

        }

        public async Task<APIResponse<IEnumerable<AppealResponse>>> GetAllTeamAppealsByStatus(Guid teamId, DonationAppealStatus appealStatus)
        {
            var donationAppeals = await repository.GetAllTeamAppealsByStatus(teamId, appealStatus);

            if (donationAppeals?.Count() > 0)
                return APIResponse<IEnumerable<AppealResponse>>.SuccessResponse(donationAppeals, APIStatusCodes.OK);

            return APIResponse<IEnumerable<AppealResponse>>.ErrorResponse("No Donation Appeals Found", APIStatusCodes.NotFound);
        }

        public async Task<int> GetTotalAppeals(DonationAppealStatus status)
        {
            if (status == DonationAppealStatus.Pending)
            {
                var res = await repository.FindByAsync(x => x.DonationAppealStatus == status);
                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else if (status == DonationAppealStatus.Approved)
            {
                var res = await repository.FindByAsync(x => x.DonationAppealStatus == status);
                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else if (status == DonationAppealStatus.Completed)
            {
                var res = await repository.FindByAsync(x => x.DonationAppealStatus == status);
                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else return 0;
        }


        public async Task<int> GetTeamTotalAppeals(Guid teamId, DonationAppealStatus status)
        {
            var appeals = await GetTeamAppeals(teamId);

            if (status == DonationAppealStatus.Pending)
            {
                var res = appeals.Result?.Where(x => x.DonationAppealStatus == status);

                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else if (status == DonationAppealStatus.Approved)
            {
                var res = appeals.Result?.Where(x => x.DonationAppealStatus == status);

                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else if (status == DonationAppealStatus.Completed)
            {
                var res = appeals.Result?.Where(x => x.DonationAppealStatus == status);
                if (res.Any())
                    return (res.Count());
                else return 0;
            }
            else return 0;
        }
    }
}
