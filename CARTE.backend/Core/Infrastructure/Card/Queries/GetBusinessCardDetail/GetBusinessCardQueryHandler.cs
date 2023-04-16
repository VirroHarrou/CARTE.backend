using AutoMapper;
using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Card.Queries.GetBusinessCardDetail
{
    public class GetBusinessCardQueryHandler : IRequestHandler<GetBusinessCardQuery, BusinessCardVm>
    {
        private readonly IBusinessCardContext _context;
        private readonly IMapper _mapper;

        public GetBusinessCardQueryHandler(IBusinessCardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BusinessCardVm> Handle(GetBusinessCardQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Cards
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(BusinessCard), request.Id);
            }

            return _mapper.Map<BusinessCardVm>(entity);
        }
    }
}
