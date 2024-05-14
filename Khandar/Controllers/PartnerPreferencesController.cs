using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    //[Route("api/[controller]")]
   // [ApiController]
    public class PartnerPreferencesController : ApiController
    {
        private readonly IPartnerPreferenceService service;

        public PartnerPreferencesController(IPartnerPreferenceService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<APIResponse<PartnerPreferenceResponse>> InsertAsync(PartnerPreferenceRequest model) => await service.InsertAsync(model);

    }
}
