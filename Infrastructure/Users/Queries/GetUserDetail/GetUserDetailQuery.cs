using MediatR;
using System.ComponentModel;

namespace Infrastructure.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserVm>
    {
        public Guid UserId { get; set; }
    }
}
