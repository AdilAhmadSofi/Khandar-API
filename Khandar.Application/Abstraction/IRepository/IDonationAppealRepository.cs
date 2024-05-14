using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IDonationAppealRepository : IBaseRepository<DonationAppeal>
    {
        Task<IEnumerable<DonationAppealByTeamResponse>> GetTeamAppeals(Guid teamId);

        //Task<IEnumerable<DonationAppealByTeamResponse>> GetAppealsForTeamLeader(Guid teamId);

        Task<IEnumerable<AppealResponse>> GetAllAppeals();

        Task<IEnumerable<AppealResponse>> GetAllApprovedAppeals();

        Task<IEnumerable<AppealResponse>> GetAllTeamAppeals(Guid teamId);

        Task<AppealResponse> GetAppealById(Guid id);

        Task<IEnumerable<DonationAppealResponse>> GetMyAppeal(Guid id);

        Task<BeneficiaryDetailsResponse> GetBeneficiaryDetails(Guid id);

        Task<IEnumerable<AppealResponse>> GetAllAppealsByStatus(DonationAppealStatus appealStatus);

        Task<IEnumerable<AppealResponse>> GetAllTeamAppealsByStatus(Guid teamId, DonationAppealStatus appealStatus);


    }
}
