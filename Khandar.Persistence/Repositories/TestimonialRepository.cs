using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Khandar.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Khandar.Persistence.Repositories;

internal sealed class TestimonialRepository : BaseRepository<Testimonial>, ITestimonialRepository
{
    private readonly KhandarDbContext context;

    public TestimonialRepository(KhandarDbContext context) : base(context)
    {
        this.context = context;
    }

    //private readonly string baseQuery = $@"SELECT T.Id, U.Id AS UserId,  U.Name,  F.FilePath ,	T.[Description], T.IsActive, T.CreatedOn
				//			                FROM Testimonials T
				//			                INNER JOIN Users U
				//			                ON U.Id = T.CustomerId
    //                                        LEFT JOIN AppFiles F
    //                                        ON U.Id = F.EntityId  ";



    private readonly string baseQuery = $@"SELECT T.Id, U.Id AS UserId,  U.Name,  F.FilePath ,	T.[Description], T.IsActive, T.CreatedOn,
										  (CASE WHEN P.ProfilePictureVisibilty = {(int)ProfilePictureVisibilty.Everyone} THEN  F.FilePath ELSE NULL END) AS FilePath

							                FROM Testimonials T
							                INNER JOIN Users U
							                ON U.Id = T.CustomerId
											INNER JOIN PartnerSeekers P
											ON U.Id =P.Id
                                            LEFT JOIN AppFiles F
                                            ON U.Id = F.EntityId  ";


    public async Task<IEnumerable<TestimonialResponse>> GetAllTestimonials()
    { 
        return await QueryAsync<TestimonialResponse>(baseQuery + " ORDER BY T.CreatedOn DESC ", null);
    }

    public async Task<IEnumerable<TestimonialResponse>> GetAllActiveTestimonials()
    {
        return await QueryAsync<TestimonialResponse>(baseQuery + " WHERE T.IsActive = 1 ORDER BY T.CreatedOn DESC ", null);
    }

    public async Task<IEnumerable<TestimonialResponse>> GetMyTestimonials(Guid customerId)
    {
        return await QueryAsync<TestimonialResponse>(baseQuery + " WHERE T.CustomerId =@customerId ORDER BY T.CreatedOn DESC ", new { customerId });

    }
}
