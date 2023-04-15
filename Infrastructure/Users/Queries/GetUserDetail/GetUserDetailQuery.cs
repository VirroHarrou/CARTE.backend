using MediatR;
using System.ComponentModel;

namespace Infrastructure.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserVm>
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
