using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, int>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<AddOrderCommandHandler> _logger;

        public AddOrderCommandHandler(IOrderRepository repository, IMapper mapper, IEmailService emailService, ILogger<AddOrderCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            Order entity = _mapper.Map<Order>(request);

            var order = await _repository.InsertAsync(entity);

            _logger.LogInformation($"Order {order.Id} created successfully");

            await SendEmail(order);

            return order.Id;
        }

        private async Task SendEmail(Order order)
        {
            Email email = new Email
            {
                To = "example@example.net",
                Subject = "Alert Message",
                Body = "Successfully"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}