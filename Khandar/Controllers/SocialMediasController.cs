using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
   // [Route("api/[controller]")]
  //  [ApiController]
    public class SocialMediasController : ApiController
    {
        private readonly ISocialMediaService service;

        public SocialMediasController(ISocialMediaService service)
        {
            this.service = service;
        }


        [HttpGet]
        public Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetAll() => service.GetAllAsync();


        [HttpPut]
        public async Task<IResult> Update(SocialMediaUpdateRequest model) => this.APIResult(await service.UpdateAsync(model));


        [HttpPost]
        public async Task<IResult> Insert(SocialMediaRequest model) => this.APIResult(await service.InsertAsync(model));


        [HttpDelete]
        public async Task<IResult> Delete(Guid id) => this.APIResult(await service.DeleteAsync(id));


        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id) => this.APIResult(await service.GetByIdAsync(id));
    }
}
