using AutoMapper;
using AutoMapper.QueryableExtensions;
using CARTE.backend.Core.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Card.Queries.GetListCards
{
    public class GetListCardsQueryHandler : IRequestHandler<GetListCardsQuery, CardsListVm>
    {
        private readonly IBusinessCardContext _context;
        private readonly IMapper _mapper;

        public GetListCardsQueryHandler(IBusinessCardContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CardsListVm> Handle(GetListCardsQuery request, CancellationToken cancellationToken)
        {
            var cardQuery = await _context.Cards
                .Where(x => x.UserId == request.Id)
                .ProjectTo<CardLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CardsListVm { Cards = cardQuery };
        }
    }
}
