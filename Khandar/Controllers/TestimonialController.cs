using KashmirServices.Application.Abstractions.IServices;
using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstractions.IServices;
using Khandar.Application.RRModels;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Khandar.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestimonialController : ApiController
{
    private readonly ITestimonialService service;

    public TestimonialController(
        ITestimonialService service)
    {
        this.service = service;
    }


    [HttpGet("all")]
    public async Task<IResult> AllTestimonial() => this.APIResult(await service.GetAllTestimonials());


    [HttpGet("all-active-testimonials")]
    public async Task<IResult> AllActiveTestimonial() => this.APIResult(await service.GetAllActiveTestimonials());


    [HttpGet("my-testimonials")]
    public async Task<IResult> MyTestimonials() => this.APIResult(await service.MyTestimonials());


    [HttpPost()]
    public async Task<IResult> AddTestimonials(TestimonialRequest model) => this.APIResult(await service.Add(model));


    [HttpPut("status-changes")]
    public async Task<IResult> PutTestimonials(UpdateTestimonialStatusRequest model) => this.APIResult(await service.ChangeTestimonialStatus(model));



    [HttpDelete("{id:guid}")]
    public async Task<IResult> DeleteTestimonial(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Results.BadRequest("Invalid ID. Please provide a valid ID.");
        }

        return this.APIResult(await service.Delete(id));
    }
}
