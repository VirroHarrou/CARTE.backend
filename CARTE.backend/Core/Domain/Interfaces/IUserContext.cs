using CARTE.backend.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Domain.Interfaces
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
