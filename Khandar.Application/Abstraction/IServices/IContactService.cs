using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstractions.IServices;

public interface IContactService
{

    Task<APIResponse<ContactResponse>> Add(ContactRequest model);


    Task<APIResponse<IEnumerable<ContactResponse>>> GetAll();


    Task<APIResponse<ContactResponse>> GetById(Guid id);
    

    Task<APIResponse<ContactResponse>> Delete(Guid id);

}
