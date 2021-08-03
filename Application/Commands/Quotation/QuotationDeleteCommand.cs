using MediatR;
using System;

namespace Application.Commands
{
    public class QuotationDeleteCommand : IRequest<Guid>
    {
        public Guid Id;
    }
}
