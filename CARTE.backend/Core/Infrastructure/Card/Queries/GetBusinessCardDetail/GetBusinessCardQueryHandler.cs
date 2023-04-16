using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Card.Queries.GetBusinessCardDetail
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
