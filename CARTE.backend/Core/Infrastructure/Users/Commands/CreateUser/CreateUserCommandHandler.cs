using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using MediatR;

namespace CARTE.backend.Core.Infrastructure.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserContext _context;

        public CreateUserCommandHandler(IUserContext context) =>
            _context = context;

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new User
            {
                Id = Guid.NewGuid(),
                Surname = request.Surname,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password.GetHashCode().ToString()
            };

            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
