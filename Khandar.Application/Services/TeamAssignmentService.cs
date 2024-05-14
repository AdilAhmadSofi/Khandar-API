using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Services
{
    public class TeamAssignmentService : ITeamAssignmentService
    {
        private readonly ITeamAssignmentRepository repository;
        private readonly IMapper mapper;
        private readonly IDonationAppealRepository donationAppealRepository;

        public TeamAssignmentService(ITeamAssignmentRepository repository, IMapper mapper, IDonationAppealRepository donationAppealRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.donationAppealRepository = donationAppealRepository;
        }

        #region Admin Calls
        public async Task<APIResponse<IEnumerable<TeamAssignedAppealResponse>>> GetTeamAssignedAppeals()
        {
            var teamAssignedAppeals = await repository.GetTeamAssignedAppeals();

            if (teamAssignedAppeals is null)
                return APIResponse<IEnumerable<TeamAssignedAppealResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
            return APIResponse<IEnumerable<TeamAssignedAppealResponse>>.SuccessResponse(teamAssignedAppeals, APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<TeamAssignmentResponse>> AssignTeam(TeamAssignmentRequest model)
        {
            var teamAssigned = await repository.FirstOrDefaultAsync(x => x.AppealId == model.AppealId && x.TeamId == model.TeamId);

            if (teamAssigned is not null)
                return APIResponse<TeamAssignmentResponse>.ErrorResponse("Team Already assigned to this Appeal", APIStatusCodes.Conflict);

            var teamAssignment = mapper.Map<TeamAssignment>(model);

            teamAssignment.TeamAssignStatus = TeamAssignStatus.Assigned;

            var appeal = await donationAppealRepository.GetByIdAsync(model.AppealId);

            if (appeal is null)
                return APIResponse<TeamAssignmentResponse>.ErrorResponse("Some Thing went wrong Please try again", APIStatusCodes.Conflict);

            appeal.DonationAppealStatus = DonationAppealStatus.Processing;
            await donationAppealRepository.UpdateAsync(appeal);

            int returnValue = await repository.InsertAsync(teamAssignment);

            if (returnValue > 0)
                return APIResponse<TeamAssignmentResponse>.SuccessResponse(mapper.Map<TeamAssignmentResponse>(teamAssignment), APIStatusCodes.OK);

            return APIResponse<TeamAssignmentResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        #endregion
      
    }
}
