using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualificationsController : ApiController
    {
        private readonly IQualificationService service;

        public QualificationsController(IQualificationService service)
        {
            this.service = service;
        }


        [HttpGet]
        public async Task<APIResponse<IEnumerable<QualificationResponse>>> GetAll() => await service.GetMyQualifications();


        [HttpPost]
        public async Task<IResult> Insert(QualificationRequest model) => this.APIResult(await service.InsertAsync(model));



        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id) => this.APIResult(await service.DeleteAsync(id));


        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id) => this.APIResult(await service.GetByIdAsync(id));
    }
}
