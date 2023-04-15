using MediatR;

namespace Infrastructure.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
