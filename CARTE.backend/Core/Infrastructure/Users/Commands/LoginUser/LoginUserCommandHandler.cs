using Domain.Interfaces;
using Domain.Models;
using Infrastructure.CustomExceptions;
using MediatR;

namespace Infrastructure.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Guid>
    {
        private readonly IUserContext _context;

        public LoginUserCommandHandler(IUserContext context) =>
            _context = context;

        public async Task<Guid> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users
                .FindAsync(new object[] { request.Email }, cancellationToken);

            if(entity == null || entity.Password != request.Password)
                throw new NotFoundException(nameof(User), request.Email);

            return entity.Id;
        }
    }
}
