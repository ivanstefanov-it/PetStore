namespace PetStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class UserConfiguration : IEntityTypeConfiguration<StoreUser>
    {
        public void Configure(EntityTypeBuilder<StoreUser> user)
        {
            user
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
