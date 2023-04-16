using MediatR;

namespace CARTE.backend.Core.Infrastructure.Card.Queries.GetBusinessCardDetail
{
    public class GetBusinessCardQuery : IRequest<BusinessCardVm>
    {
        public Guid Id { get; set; }
    }
}
