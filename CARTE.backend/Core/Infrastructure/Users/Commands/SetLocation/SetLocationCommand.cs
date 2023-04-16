using MediatR;

namespace Infrastructure.Users.Commands.SetLocation
{
    public class SetLocationCommand : IRequest
    {
        public Guid UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
