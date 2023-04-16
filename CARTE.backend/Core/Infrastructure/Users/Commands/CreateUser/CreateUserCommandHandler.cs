using Domain.Interfaces;
using Domain.Models;
using MediatR;

namespace Infrastructure.Users.Commands.CreateUser
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
                Password = request.Password
            };

            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
