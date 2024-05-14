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
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamMemberRepository repository;
        private readonly IMapper mapper;
        private readonly IContextService contextService;
        private readonly ITeamRepository teamRepository;

        public TeamMemberService(ITeamMemberRepository repository,
            IMapper mapper,
            IContextService contextService,
            ITeamRepository teamRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.contextService = contextService;
            this.teamRepository = teamRepository;
        }

        public async Task<APIResponse<TeamMemberResponse>> InsertAsync(TeamMemberRequest model)
        {

            var memeberAvail = await repository.IsExist(x => x.MemberId == model.MemberId && x.TeamId == model.TeamId);

            if (memeberAvail)
                return APIResponse<TeamMemberResponse>.ErrorResponse("Member is already part of team", APIStatusCodes.Conflict);

            var leaderExist = await repository.FirstOrDefaultAsync(x => x.TeamId == model.TeamId && x.MemberType == MemberType.Leader);

            if(leaderExist is not null)
            {
                if(model.MemberType == MemberType.Leader)
                {
                    return APIResponse<TeamMemberResponse>.ErrorResponse("Leader already assigned", APIStatusCodes.Conflict);
                }
            }


            var teamMember = mapper.Map<TeamMember>(model);

            int returnValue = await repository.InsertAsync(teamMember);

            if (returnValue > 0)
                return APIResponse<TeamMemberResponse>.SuccessResponse(mapper.Map<TeamMemberResponse>(teamMember),"Member added successfully");

                return APIResponse<TeamMemberResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
        }

        public async Task<APIResponse<IEnumerable<TeamMemberInfoResponse>>> GetAllTeamMembersByTeamId(Guid teamid)
        {
            var teamMembers = await repository.GetAllTeamMembersByTeamId(teamid);
            if (teamMembers.Any())
                return APIResponse<IEnumerable<TeamMemberInfoResponse>>.SuccessResponse(teamMembers, APIStatusCodes.OK);

            return APIResponse<IEnumerable<TeamMemberInfoResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<TeamMemberInfoResponse>> GetByMemberIdAsync(Guid id)
        {
            var team = await repository.GetByMemberIdAsync(id);

            if (team is null)
                return APIResponse<TeamMemberInfoResponse>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

            return APIResponse<TeamMemberInfoResponse>.SuccessResponse(mapper.Map<TeamMemberInfoResponse>(team), APIStatusCodes.OK);

        }

        public async Task<APIResponse<string>> AssignTeamLeader(Guid memberId)
        {
            var teamMember = await repository.GetByIdAsync(memberId);

            teamMember.MemberType = MemberType.Leader;

            int returnValue = await repository.UpdateAsync(teamMember);

            if (returnValue > 0)
                return APIResponse<string>.SuccessResponse("Leader Assigned Successfully", APIStatusCodes.OK);
            return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

        }
    }
}
