using DuckAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DuckAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Duckuser> Duckusers { get; set; }
        public DbSet<Duck> Ducks { get; set; }
        public DbSet<Ducklore> Ducklores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Duck>()
                .Property(d => d.DuckID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Duckuser>()
                .Property(d => d.DuckUserID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Duck>()
                .HasOne(d => d.Ducklore)
                .WithMany(d => d.Ducks)
                .HasForeignKey(d => d.DuckloreID);
        }
    }
}
