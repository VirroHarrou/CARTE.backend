using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using CARTE.backend.Core.Infrastructure.CustomExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Infrastructure.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Guid>
    {
        private readonly IUserContext _context;

        public LoginUserCommandHandler(IUserContext context) =>
            _context = context;

        public async Task<Guid> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .Where(x => x.Password == request.Password.GetHashCode().ToString() && x.Email == request.Email)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.Email);

            return entity.Id;
        }
    }
}
