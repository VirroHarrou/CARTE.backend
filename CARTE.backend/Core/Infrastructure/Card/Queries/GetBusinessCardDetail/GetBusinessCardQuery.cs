using MediatR;

namespace Infrastructure.Card.Queries.GetBusinessCardDetail
{
    public class GetBusinessCardQuery : IRequest<BusinessCardVm>
    {
        public Guid Id { get; set; }
    }
}
