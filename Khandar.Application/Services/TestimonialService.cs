using AutoMapper;
using KashmirServices.Application.Abstractions.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.Abstractions.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KashmirServices.Application.Services;

public class TestimonialService : ITestimonialService
{
    private readonly ITestimonialRepository repository;
    private readonly IMapper mapper;
    private readonly IContextService contextService;

    public TestimonialService(ITestimonialRepository repository, IMapper mapper, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.contextService = contextService;
    }


    public async Task<APIResponse<string>> Add(TestimonialRequest model)
    {
        Testimonial testimonial = new()
        {
            Description = model.Description,
            IsActive = false,
            CustomerId = contextService.GetUserId().Value
        };

        int returnValue = await repository.InsertAsync(testimonial);
        if (returnValue > 0)
            return APIResponse<string>.SuccessResponse("Testimonial added successfully");

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
    }


    public async Task<APIResponse<string>> ChangeTestimonialStatus(UpdateTestimonialStatusRequest model)
    {
        var testimonial = await repository.GetByIdAsync(model.Id);
        if (testimonial is null)
            return APIResponse<string>.ErrorResponse("No testimonial found", APIStatusCodes.NotFound);

        testimonial.IsActive = model.Status;

        int returnValue = await repository.UpdateAsync(testimonial);

        if (returnValue > 0)
        {
            if(model.Status)
               return APIResponse<string>.SuccessResponse(null,  $"Testimonial Is Now Active ");

               return APIResponse<string>.SuccessResponse(null,  $"Testimonial Is Now InActive ");
        }

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

    }


    public async Task<APIResponse<string>> Delete(Guid id)
    {
        var testimonial = await repository.GetByIdAsync(id);
        if (testimonial is null)
            return APIResponse<string>.ErrorResponse("No testimonial found", APIStatusCodes.NotFound);


        int returnValue = await repository.DeleteAsync(testimonial);

        if (returnValue > 0)
            return APIResponse<string>.SuccessResponse("Testimonial deleted successfully");

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
    }


    public async Task<APIResponse<IEnumerable<TestimonialResponse>>> GetAllActiveTestimonials()
    {
        var testimonials = await repository.GetAllActiveTestimonials();

        if (testimonials.Any())
            return APIResponse<IEnumerable<TestimonialResponse>>.SuccessResponse(testimonials,"success");

        return APIResponse<IEnumerable<TestimonialResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);
    }


    public async Task<APIResponse<IEnumerable<TestimonialResponse>>> GetAllTestimonials()
    {
        var testimonials = await repository.GetAllTestimonials();

        if (testimonials.Any())
            return APIResponse<IEnumerable<TestimonialResponse>>.SuccessResponse(testimonials, "success");

        return APIResponse<IEnumerable<TestimonialResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

    }
  

    public async Task<APIResponse<IEnumerable<TestimonialResponse>>> MyTestimonials()
    {
        var customerId = contextService.GetUserId().Value;
        var testimonials = await repository.GetMyTestimonials(customerId);

        if (testimonials.Any())
            return APIResponse<IEnumerable<TestimonialResponse>>.SuccessResponse(testimonials, "success");

        return APIResponse<IEnumerable<TestimonialResponse>>.ErrorResponse(APIMessages.NotFound, APIStatusCodes.NotFound);

    }
}
