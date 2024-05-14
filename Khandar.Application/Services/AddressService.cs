using AutoMapper;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.Abstractions.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository repository;
    private readonly IMapper mapper;
    private readonly IContextService contextService;

    public AddressService(IAddressRepository repository, IMapper mapper, IContextService contextService)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.contextService = contextService;
    }

    public async Task<APIResponse<AddressResponse>> Add(AddressRequest model)
    {
        var address = mapper.Map<Address>(model);
        address.EntityId = model.EntityId ?? contextService.GetUserId().Value;
        address.CreatedBy = address.EntityId;
        address.Module = model.Module;


        var dbAddresses = await repository.FindByAsync(x => x.EntityId == address.EntityId);
        if(dbAddresses.Any())
        {
            if (model.IsNative)
            {
                var currentAddress =  dbAddresses.FirstOrDefault(add => add.EntityId == address.EntityId && add.IsNative == true);

                if (currentAddress is not null)
                {
                    currentAddress.IsNative = false;
                    await repository.UpdateAsync(currentAddress);
                }
            }
            int returnValue = await repository.InsertAsync(address);
            if (returnValue > 0)
            {
                var response = mapper.Map<AddressResponse>(address);
                response.Id = address.Id;
                return APIResponse<AddressResponse>.SuccessResponse(response, "Address saved successfully.", APIStatusCodes.Created);
            }
        }
        else
        {
            address.IsNative = true;
            int returnValue = await repository.InsertAsync(address);
            if (returnValue > 0)
            {
                var response = mapper.Map<AddressResponse>(address);
                response.Id = address.Id;
                return APIResponse<AddressResponse>.SuccessResponse(response, "Address saved successfully.", APIStatusCodes.Created);
            }
        }

        return APIResponse<AddressResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
    }



    public async Task<APIResponse<IEnumerable<AddressResponse>>> GetAll(Module model)
    {

        var addresses = await repository.FindByAsync(address => address.Module == model && address.IsDeleted ==false);

        if (addresses.Any())
            return APIResponse<IEnumerable<AddressResponse>>.SuccessResponse(mapper.Map<IEnumerable<AddressResponse>>(addresses), $"Found {addresses.Count()} addresses", APIStatusCodes.OK);

        return APIResponse<IEnumerable<AddressResponse>>.ErrorResponse("No addresses found", APIStatusCodes.NoContent);
    }


    public async Task<APIResponse<AddressResponse>> GetById(Guid id)
    {
        var address = await repository.GetByIdAsync(id);

        if (address is not null)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address found", APIStatusCodes.OK);

        return APIResponse<AddressResponse>.ErrorResponse("No Address found", APIStatusCodes.NotFound);
    }


    public async Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId(Guid? id)
    {
        var entityId = id ?? contextService.GetUserId();
        var addresses = await repository.FindByAsync(address => address.EntityId == entityId && address.IsDeleted == false);


        if (addresses.Any())
            return APIResponse<IEnumerable<AddressResponse>>.SuccessResponse(mapper.Map<IEnumerable<AddressResponse>>(addresses), $"Found {addresses.Count()} addresses", APIStatusCodes.OK);

        return APIResponse<IEnumerable<AddressResponse>>.ErrorResponse("No addresses found", APIStatusCodes.NoContent);
    }



    public async Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model)
    {
        var dbAddress = await repository.GetByIdAsync(model.Id);

        var address = mapper.Map(model, dbAddress);
        address.EntityId = model.EntityId ?? contextService.GetUserId();

        int returnValue = await repository.UpdateAsync(address);
        if (returnValue > 0)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address updated succesfully.", APIStatusCodes.Created);

        return APIResponse<AddressResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

    }



    public async Task<APIResponse<AddressResponse>> Delete(Guid? id)
    {
        var address = await repository.GetByIdAsync(id ?? contextService.GetUserId().Value);


        if (address is null)
            return APIResponse<AddressResponse>.ErrorResponse("No address found", APIStatusCodes.NotFound);

        address.IsDeleted = true;
        
        int returnValue = await repository.UpdateAsync(address);


        if (returnValue > 0)
            return APIResponse<AddressResponse>.SuccessResponse(mapper.Map<AddressResponse>(address), "Address deleted successfully", APIStatusCodes.OK);

        return APIResponse<AddressResponse>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);

    }
}
