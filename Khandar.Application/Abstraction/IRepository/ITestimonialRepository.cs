using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstractions.IRepositories;

public interface ITestimonialRepository : IBaseRepository<Testimonial>
{
    Task<IEnumerable<TestimonialResponse>> GetAllTestimonials();


    Task<IEnumerable<TestimonialResponse>> GetAllActiveTestimonials();

    Task<IEnumerable<TestimonialResponse>> GetMyTestimonials(Guid customerId);
}
