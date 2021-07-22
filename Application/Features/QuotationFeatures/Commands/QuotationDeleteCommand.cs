using MediatR;
using System;

namespace Application.Features.QuotationFeatures.Commands
{
    public class QuotationDeleteCommand : IRequest<Guid>
    {
        public Guid Id;
    }
}
