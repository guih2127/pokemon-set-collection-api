using Microsoft.EntityFrameworkCore;
using pokemon_tcg_collection_api.Models;

namespace pokemon_tcg_collection_api.Context
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserCardEntity> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasMany(m => m.CardsObtained)
                .WithOne(c => c.User);
        }
    }
}
