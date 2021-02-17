using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetStore.Data.Models;

namespace PetStore.Data
{
    public class PetStoreDbContext : IdentityDbContext<StoreUser>
    {
        public PetStoreDbContext()
        {

        }

        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<FoodOrder> FoodOrders { get; set; }

        public DbSet<StoreUser> User { get; set; }

        public DbSet<ToyOrder> ToyOrders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PetStoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
