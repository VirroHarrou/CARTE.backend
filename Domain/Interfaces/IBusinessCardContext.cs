using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface IBusinessCardContext
    {
        DbSet<BusinessCard> Cards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
