using MediatR;

namespace CARTE.backend.Core.Infrastructure.Users.Commands.SetLocation
{
    public class SetLocationCommand : IRequest
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
