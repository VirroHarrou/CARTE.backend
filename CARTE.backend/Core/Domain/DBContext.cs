using CARTE.backend.Core.Domain.Interfaces;
using CARTE.backend.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CARTE.backend.Core.Domain
{
    public class DBContext : DbContext, IUserContext, IBusinessCardContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<BusinessCard> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
