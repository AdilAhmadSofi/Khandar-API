using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class JobHistoriesController : ApiController
    {
        private readonly IJobHistoryService service;

        public JobHistoriesController(IJobHistoryService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<APIResponse<JobHistoryResponse>> Insert(JobHistoryRequest model) => await service.InsertAsync(model);


        [HttpGet]
        public async Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetAll() => await service.GetAllAsync();


        [HttpGet("{id:guid}")]
        public async Task<APIResponse<JobHistoryResponse>> GetById(Guid id) => await service.GetByIdAsync(id);


        [HttpDelete("{id:guid}")]
        public async Task<APIResponse<JobHistoryResponse>> Delete(Guid id) => await service.DeleteAsync(id);
    }
}
