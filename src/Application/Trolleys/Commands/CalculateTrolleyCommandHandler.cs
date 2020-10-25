using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Trolleys.Commands
{
    public class CalculateTrolleyCommandHandler : IRequestHandler<CalculateTrolleyCommand, decimal>
    {
        public Task<decimal> Handle(CalculateTrolleyCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
