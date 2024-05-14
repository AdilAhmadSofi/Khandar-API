using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository repository;
        private readonly IContextService contextService;
        private readonly IMapper mapper;

        public TeamService(ITeamRepository repository, IContextService contextService, IMapper mapper)
        {
            this.repository = repository;
            this.contextService = contextService;
            this.mapper = mapper;
        }


        public async Task<APIResponse<TeamResponse>> InsertAsync(TeamRequest model)
        {

            var teamExists = await repository.IsExist(t => t.Name == model.Name);

            if (teamExists)
                return APIResponse<TeamResponse>.ErrorResponse("Team Name Already Exists, choose Different Name", APIStatusCodes.BadRequest);

            var team = mapper.Map<Team>(model);
            int returnValue = await repository.InsertAsync(team);

            if (returnValue > 0)
            return APIResponse<TeamResponse>.SuccessResponse(mapper.Map<TeamResponse>(team),"Team added successfully");

                return APIResponse<TeamResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<IEnumerable<TeamResponse>>> GetAllAsync()
        {
            var teams = await repository.GetAllAsync();
            if (teams.Any())
                return APIResponse<IEnumerable<TeamResponse>>.SuccessResponse(mapper.Map<IEnumerable<TeamResponse>>(teams), APIStatusCodes.OK);

            return APIResponse<IEnumerable<TeamResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<TeamResponse>> GetByIdAsync(Guid id)
        {
           

            var team = await repository.GetByIdAsync(id);

            if (team is null)
                return APIResponse<TeamResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<TeamResponse>.SuccessResponse(mapper.Map<TeamResponse>(team), APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<TeamResponse>>> GetMyTeams(Guid? id)
        {
            var userId = id ?? contextService.GetUserId().Value;
            var teams = await repository.GetMyTeamsAsync(userId);
            if (teams.Any())
                return APIResponse<IEnumerable<TeamResponse>>.SuccessResponse(teams, APIStatusCodes.OK);

            return APIResponse<IEnumerable<TeamResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
        }
    }
}
