using Domain.Models;

namespace Infrastructure.Users.Queries.GetUserDetail
{
    public class UserVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<BusinessCard> Cards { get; set; }
    }
}
