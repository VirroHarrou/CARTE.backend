using Domain.Interfaces;
using Domain.Models;
using Infrastructure.CustomExceptions;
using MediatR;

namespace Infrastructure.Users.Commands.SetLocation
{
    public class SetLocationCommandHandler : IRequestHandler<SetLocationCommand>
    {
        private readonly IUserContext _context;

        public SetLocationCommandHandler(IUserContext context) => 
            _context = context;

        public async Task Handle(SetLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(new object[] { request.UserId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.UserId);

            entity.Longitude = request.Longitude;
            entity.Latitude = request.Latitude;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
