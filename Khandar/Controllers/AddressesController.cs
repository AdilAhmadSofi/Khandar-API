using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstractions.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class AddressesController : ApiController
{

    private readonly IAddressService service;
    public AddressesController(IAddressService service)
    {
        this.service = service;
    }



    [AllowAnonymous]
    [HttpPost]
    public async Task<APIResponse<AddressResponse>> Add(AddressRequest model) => await service.Add(model);

    [AllowAnonymous]
    [HttpGet("address-by-module")]
    public async Task<APIResponse<IEnumerable<AddressResponse>>> GetAll([FromQuery] Module model) => await service.GetAll(model);


    [HttpGet("{id:guid}")]
    public async Task<APIResponse<AddressResponse>> GetById([FromRoute] Guid id) => await service.GetById(id);


    [HttpPut]
    public async Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model) => await service.Update(model);

    [AllowAnonymous]
    [HttpDelete()]
    public async Task<APIResponse<AddressResponse>> Delete([FromQuery] Guid? id) => await service.Delete(id);


    [AllowAnonymous]
    [HttpGet("entityid")]
    public Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId([FromQuery] Guid? entityid) => service.GetByEntityId(entityid);
}
