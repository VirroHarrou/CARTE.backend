using MediatR;
using System.ComponentModel;

namespace CARTE.backend.Core.Infrastructure.Users.Queries.GetUserDetail
{
    public class GetUserDetailQuery : IRequest<UserVm>
    {
        public Guid UserId { get; set; }
    }
}
