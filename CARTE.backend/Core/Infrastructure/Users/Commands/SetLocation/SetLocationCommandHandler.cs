using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;

namespace CARTE.backend.Core.Infrastructure.Users.Commands.SetLocation
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
