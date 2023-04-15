using MediatR;

namespace Infrastructure.Card.Commands.UpdateCard
{
    public class UpdateCardCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<string> Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Urls { get; set; }
    }
}
