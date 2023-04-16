using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
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
