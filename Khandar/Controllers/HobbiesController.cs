using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class HobbiesController : ApiController
    {
        private readonly IHobbyService service;

        public HobbiesController(IHobbyService service)
        {
            this.service = service;
        }


        [HttpGet]
        public Task<APIResponse<IEnumerable<HobbyResponse>>> GetAll() => service.GetAllAsync();


        [HttpPost]
        public async Task<IResult> Insert(HobbyRequest model) => this.APIResult(await service.Insert(model));



        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id) => this.APIResult(await service.Delete(id));
    }
}
