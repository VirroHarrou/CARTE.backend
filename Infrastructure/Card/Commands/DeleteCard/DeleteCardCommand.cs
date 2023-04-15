using MediatR;

namespace Infrastructure.Card.Commands.DeleteCard
{
    public class DeleteCardCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
    }
}
