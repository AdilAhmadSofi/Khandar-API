using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Enums;

namespace Khandar.Application.Abstractions.IServices;

public interface IAddressService
{

    Task<APIResponse<AddressResponse>> Add(AddressRequest model);


    Task<APIResponse<IEnumerable<AddressResponse>>> GetAll(Module model);


    Task<APIResponse<AddressResponse>> GetById(Guid id);
    

    //Task<APIResponse<IEnumerable<AddressResponse>>> GetByUserId();


    Task<APIResponse<IEnumerable<AddressResponse>>> GetByEntityId(Guid? id);


    Task<APIResponse<AddressResponse>> Update(AddressUpdateRequest model);


    Task<APIResponse<AddressResponse>> Delete(Guid? id);

}
