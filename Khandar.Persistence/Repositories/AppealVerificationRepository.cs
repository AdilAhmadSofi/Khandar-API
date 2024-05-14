using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class AppealVerificationRepository : BaseRepository<AppealVerification>, IAppealVerificationRepostory
    {
        public AppealVerificationRepository(KhandarDbContext context) : base(context)
        {

        }

        //private readonly string query = $@" 	SELECT D.BeneficiaryId, B.[Name] AS BeneficiaryName, B.ContactNo AS BeneficiaryContactNo,
        //				D.Amount, D.DonationAppealStatus,TA.AppealId,
        //				T.[Name] AS TeamName , T.[Location], U.[Name] AS 
        //				MemberName, AV.MemberId, U.ContactNo, AV.Remarks, 
        //				AV.Feedback, AV.CreatedOn AS VerificationDate, D.CreatedOn AS AppealDate
        //				from DonationAppeals D
        //				LEFT JOIN TeamAssignments TA
        //				ON D.Id = TA.AppealId
        //				LEFT JOIN Teams T
        //				ON T.Id = TA.TeamId
        //				LEFT JOIN AppealVerifications AV
        //				ON AV.TeamAssignmentId = TA.Id
        //				LEFT JOIN Members M 
        //				ON M.Id = AV.MemberId
        //				LEFT JOIN Users U
        //				ON U.Id = M.Id
        //				LEFT JOIN Users B
        //				ON B.Id = D.BeneficiaryId
        //                                        WHERE TA.TeamAssignmentId = @teamAssignmentId ";

        //string query = $@" SELECT AV.Id AS VerificationId,TA.Id AS TeamAssignmentId, D.BeneficiaryId, U.[Name] AS 
        //					MemberName, AV.MemberId, TM.MemberType, U.ContactNo AS MemberContactNo, AV.Remarks, 
        //					AV.Feedback, AV.CreatedOn AS VerificationDate, D.CreatedOn AS AppealDate, D.DonationAppealStatus
        //					from DonationAppeals D
        //					INNER JOIN TeamAssignments TA
        //					ON D.Id = TA.AppealId
        //					INNER JOIN Teams T
        //					ON T.Id = TA.TeamId
        //					INNER JOIN AppealVerifications AV
        //					ON AV.TeamAssignmentId = TA.Id
        //					INNER JOIN Members M 
        //					ON M.Id = AV.MemberId
        //					INNER JOIN Users U
        //					ON U.Id = M.Id
        //					INNER JOIN TeamMembers TM
        //					ON TM.TeamId = T.Id
        //			        WHERE TA.Id = @teamAssignmentId ";

        string query = $@"SELECT AV.Id AS VerificationId,TA.Id AS TeamAssignmentId, D.BeneficiaryId, U.[Name] AS 
							MemberName, AV.MemberId, U.ContactNo AS MemberContactNo, AV.Remarks, 
							AV.Feedback, AV.CreatedOn AS VerificationDate, D.CreatedOn AS AppealDate, D.DonationAppealStatus
							from DonationAppeals D
							INNER JOIN TeamAssignments TA
							ON D.Id = TA.AppealId
							INNER JOIN Teams T
							ON T.Id = TA.TeamId
							INNER JOIN AppealVerifications AV
							ON AV.TeamAssignmentId = TA.Id
							INNER JOIN Members M 
							ON M.Id = AV.MemberId
							INNER JOIN Users U
							ON U.Id = M.Id
					        WHERE TA.Id = @teamAssignmentId ORDER BY AV.CreatedOn DESC ";

        public async Task<IEnumerable<AppealMemberVerificationResponse>> GetAllVerifications(Guid teamAssignmentId)
        {
            return await QueryAsync<AppealMemberVerificationResponse>(query, new { teamAssignmentId });
        }

        public async Task<AppealMemberVerificationResponse> GetMemberVerificationsByMemberId(Guid teamAssignmentId, Guid memberId)
        {
            return await FirstOrDefaultAsync<AppealMemberVerificationResponse>(query +$@" AND AV.MemberId = @memberId", new { teamAssignmentId, memberId });
        }
    }
}
