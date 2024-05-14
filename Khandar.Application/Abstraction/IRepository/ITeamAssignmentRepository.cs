using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface ITeamAssignmentRepository:IBaseRepository<TeamAssignment>
    {
        Task<IEnumerable<TeamAssignedAppealResponse>> GetTeamAssignedAppeals();

    }
}
