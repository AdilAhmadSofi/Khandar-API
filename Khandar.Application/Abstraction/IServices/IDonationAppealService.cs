using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstraction.IServices;

public interface IDonationAppealService
{
    Task<APIResponse<DonationAppealResponse>> InsertAsync(DonationAppealRequest model);

    Task<APIResponse<AppealResponse>> UpdateAppealStatus(UpdateAppealStatusRequest model);

    Task<APIResponse<IEnumerable<DonationAppealResponse>>> UpdateAppeal(UpdateAppealRequest model);

    Task<APIResponse<IEnumerable<DonationAppealResponse>>> GetMyAppeal();

    Task<APIResponse<BeneficiaryDetailsResponse>> GetBeneficiaryDetails(Guid id);




    Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetTeamAppeals(Guid teamId);

    //Task<APIResponse<IEnumerable<DonationAppealByTeamResponse>>> GetAppealsForTeamLeader(Guid teamId);

    Task<APIResponse<IEnumerable<AppealResponse>>> GetAllAppeals();

    Task<APIResponse<IEnumerable<AppealResponse>>> GetAllApprovedAppeals();

    Task<APIResponse<IEnumerable<AppealResponse>>> GetAllAppealsByStatus(DonationAppealStatus appealStatus);


    Task<APIResponse<IEnumerable<AppealResponse>>> GetAllTeamAppeals(Guid teamId);
    Task<APIResponse<IEnumerable<AppealResponse>>> GetAllTeamAppealsByStatus(Guid teamId,  DonationAppealStatus appealStatus);

    Task<int> GetTotalAppeals(DonationAppealStatus status);

    Task<int> GetTeamTotalAppeals(Guid teamId, DonationAppealStatus status);
}


