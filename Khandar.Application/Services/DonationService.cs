using AutoMapper;
using Khandar.Application.Abstractions.IRepository;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IEmailService;
using Khandar.Application.Abstractions.IPaymentGatewayService;
using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.Abstractions.IRepository;
using Khandar.Application.Abstractions.TemplateRenderer;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Application.Utils;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using System.Security.Cryptography;
using System.Security.Principal;

namespace Khandar.Application.Services
{
    public class DonationService : IDonationService
    {
        private readonly IDonationRepository repository;
        private readonly IContextService contextService;
        private readonly IDonationAppealRepository appealRepository;
        private readonly IPaymentGatewayService paymentGatewayService;
        private readonly IOrderRepository orderRepository;
        private readonly IUserRepository userRepository;
        private readonly IPaymentRepository paymentRepository;
        private readonly IMapper mapper;

        public DonationService(IDonationRepository repository, IContextService contextService,
            IDonationAppealRepository appealRepository, IPaymentGatewayService paymentGatewayService,
            IOrderRepository orderRepository, IUserRepository userRepository, IPaymentRepository paymentRepository,
            IMapper mapper)
        {
            this.repository = repository;
            this.contextService = contextService;
            this.appealRepository = appealRepository;
            this.paymentGatewayService = paymentGatewayService;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
            this.paymentRepository = paymentRepository;
            this.mapper = mapper;
        }



        public async Task<APIResponse<AppOrderResponse>> CreateOrder(AppOrderRequest model)
        {
            var appeal = await appealRepository.GetByIdAsync(model.AppealId);
            if (appeal is null) return APIResponse<AppOrderResponse>.ErrorResponse("No Appeal found", APIStatusCodes.NotFound);

            AppOrder userOrder = new();
            userOrder.Id = Guid.NewGuid();
            userOrder.TotalAmount = model.Amount;

            userOrder.Receipt = "Khandar-" + new Random().Next(1000, 99999);

            var appOrder = paymentGatewayService.CreateOrder(userOrder);

            if (appOrder.OrderStatus == AppOrderStatus.Created)
            {
                appOrder.Id = Guid.NewGuid();
                appOrder.AppealId = model.AppealId;
                var appOrderResponse = mapper.Map<AppOrderResponse>(appOrder);
           
              
                appOrder.UserId = contextService.GetUserId()!.Value;
                var account = await userRepository.GetByIdAsync(appOrder.UserId.Value);
                appOrderResponse.Name = account!.Name;
                appOrderResponse.Email = account.Email;
                appOrderResponse.Contact = account.ContactNo;

                int returnValue = await orderRepository.SaveOrder(appOrder);


                return APIResponse<AppOrderResponse>.SuccessResponse(appOrderResponse, APIStatusCodes.OK, "Success");
            }
            return APIResponse<AppOrderResponse>.ErrorResponse("Something went wrong", APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<PaymentDetailsResponse>> CapturePaymentDetails(PaymentDetailsRequest model)
        {
            var appPayment = await paymentGatewayService.CapturePayment(model);
            var order = await orderRepository.FirstOrDefaultAsync(e => e.OrderId == model.razorpay_order_id);
            appPayment.OrderId = order!.Id;
            int returnValue = await paymentRepository.InsertAsync(appPayment);
            if (returnValue > 0)
            {
                return APIResponse<PaymentDetailsResponse>.SuccessResponse(new PaymentDetailsResponse { IsPaymentSuccessfull = true }, APIStatusCodes.OK);
            }
            return APIResponse<PaymentDetailsResponse>.ErrorResponse("There is some issue please try after sometime", APIStatusCodes.InternalServerError);
        }


        public async Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactions()
        {
            var transactions = await repository.GetAllTransactions();

            if (transactions.Any())
            return APIResponse<IEnumerable<TransactionResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
               
            return APIResponse<IEnumerable<TransactionResponse>>.ErrorResponse("No transaction found", APIStatusCodes.NotFound);
        }

        public async Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsByAppealId(Guid appealId)
        {
            var transactions = await repository.GetAllTransactionsByAppealId(appealId);

            if (!transactions.Any())
                return APIResponse<IEnumerable<TransactionResponse>>.ErrorResponse("No transaction found", APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<TransactionResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<MyTransactionResponse>>> GetMyTransactions(Guid? userId)
        {
            var id = userId ?? contextService.GetUserId().Value;
            var transactions = await repository.GetMyTransactions(id);

            if (!transactions.Any())
                return APIResponse<IEnumerable<MyTransactionResponse>>.ErrorResponse("No transaction found", APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<MyTransactionResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
        }

        public async Task<int> GetAllTransactionTotal()
        {
            return await repository.GetAllTransactionTotal();
        }

        public async Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsByDate(DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var transactions = await repository.GetAllTransactionsByDate(fromDate, toDate);

            if (!transactions.Any())
                return APIResponse<IEnumerable<TransactionResponse>>.ErrorResponse("No transaction found", APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<TransactionResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<TransactionResponse>>> GetAllTransactionsAsOfNow(DateTimeOffset toDate)
        {
            var transactions = await repository.GetAllTransactionsAsOfNow(toDate);

            if (!transactions.Any())
                return APIResponse<IEnumerable<TransactionResponse>>.ErrorResponse("No transaction found", APIStatusCodes.NotFound);

            return APIResponse<IEnumerable<TransactionResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
        }

        public async Task<APIResponse<IEnumerable<AppealSummaryResponse>>> GetAllAppealSummary(int totalCount)
        {
            var transactions = await repository.GetAllAppealSummary(totalCount);
            return APIResponse<IEnumerable<AppealSummaryResponse>>.SuccessResponse(transactions, APIStatusCodes.OK);
        }
    }
}
