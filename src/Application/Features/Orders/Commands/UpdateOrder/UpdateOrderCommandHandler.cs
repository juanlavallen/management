using System.Text.Json;
using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IOrderRepository repository, ILogger<UpdateOrderCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _repository.GetById(request.Id);

            if (order == null)
            {
                _logger.LogError($"Order with Id: {request.Id} not found");

                throw new NotFoundException(nameof(Order), request.Id);
            }

            _mapper.Map(request, order, typeof(UpdateOrderCommand), typeof(Order));

            await _repository.UpdateAsync(order);

            _logger.LogInformation("Order updated successfully: ", JsonSerializer.Serialize<Order>(order));

            return Unit.Value;
        }
    }
}