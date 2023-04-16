using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Card.Queries.GetListCards
{
    public class GetListCardsQuery : IRequest<CardsListVm>
    {
        public Guid Id { get; set; }
    }
}
