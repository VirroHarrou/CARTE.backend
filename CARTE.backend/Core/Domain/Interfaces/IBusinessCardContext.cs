using CARTE.backend.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Domain.Interfaces
{
    public interface IBusinessCardContext
    {
        DbSet<BusinessCard> Cards { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
