namespace EduVerse.API.Data.EntityConfigurations
{
    public class UserRolesEntityTypeConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasMany(u => u.Users)
                .WithMany(l => l.Roles)
                .UsingEntity(j => j.ToTable("UserRoles"));

            builder.HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
