using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
