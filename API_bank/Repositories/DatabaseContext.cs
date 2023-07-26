using API_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace API_bank.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conta>(entity =>
            {
                entity.Property(e => e.data_criacao).HasDefaultValueSql("(now())");

            });

        }
    }
}
