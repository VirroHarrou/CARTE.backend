using MediatR;

namespace CARTE.backend.Core.Infrastructure.Card.Commands.CreateCard
{
    public class CreateCardCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Patronymic { get; set; }
        public List<string> Description { get; set; }
        public List<string> ImageUrls { get; set; }
        public List<string> Urls { get; set; }
    }
}
