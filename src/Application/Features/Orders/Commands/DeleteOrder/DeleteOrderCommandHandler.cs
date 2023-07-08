using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IOrderRepository repository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _repository.GetById(request.Id);

            if (order == null)
            {
                _logger.LogError($"Order with Id: {request.Id} not found");

                throw new NotFoundException(nameof(Order), request.Id);
            }

            await _repository.DeleteAsync(order.Id);

            _logger.LogInformation("Order removed successfully");

            return Unit.Value;
        }
    }
}