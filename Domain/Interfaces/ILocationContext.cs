using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    internal interface ILocationContext
    {
        DbSet<Location> Locations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
