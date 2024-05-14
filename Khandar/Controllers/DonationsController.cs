using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Khandar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationsController : ApiController
    {
        private readonly IDonationService service;

        public DonationsController(IDonationService service)
        {
            this.service = service;
        }


        [HttpPost("CreateOrder")]
        public Task<APIResponse<AppOrderResponse>> CreateOrder(AppOrderRequest model)
        {
            return service.CreateOrder(model);
        }



        [HttpPost("CapturePaymentDetails")]
        public async Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model)
        {
            return await service.CapturePaymentDetails(model);
        }


        [HttpGet("all-transactions")]
        public async Task<IResult> GetAllTransactions() => this.APIResult(await service.GetAllTransactions());



        [HttpGet("all-transactions-appealid/{appealId:guid}")]
        public async Task<IResult> GetAllTransactionsByAppeal(Guid appealId) => this.APIResult(await service.GetAllTransactionsByAppealId(appealId));


        [HttpGet("my-transactions")]
        public async Task<IResult> GetMyTransactions([FromQuery] Guid? userId) => this.APIResult(await service.GetMyTransactions(userId));


        [HttpGet("total-transactions")]
        public async Task<int> GetAllTransactionTotal() => await service.GetAllTransactionTotal();


        [HttpGet("all-transactions-from-to")]
        public async Task<IResult> GetAllTransactionsByDate([FromQuery] DateTimeOffset fromDate, [FromQuery] DateTimeOffset toDate) => this.APIResult(await service.GetAllTransactionsByDate(fromDate, toDate));


        [HttpGet("all-transactions-as-of-now")]
        public async Task<IResult> GetAllTransactionsAsOfNow([FromQuery] DateTimeOffset toDate) => this.APIResult(await service.GetAllTransactionsAsOfNow(toDate));

        [HttpGet("appeal-summary")]
        public async Task<IResult> GetAllAppealSummaries(int count) => this.APIResult(await service.GetAllAppealSummary(count));
    }
}
