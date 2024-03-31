namespace EduVerse.API.Data.EntityConfigurations
{
    public class ParentEntityTypeConfiguration : IEntityTypeConfiguration<ParentEntity>
    {
        public void Configure(EntityTypeBuilder<ParentEntity> builder)
        {
            builder.ToTable("Parent");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(p => p.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.ParentalStatus)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13)
                .IsFixedLength();

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Work)
                .IsRequired(false)
                .HasMaxLength(55);

            builder.Property(p => p.PictureFileName)
                .IsRequired(false)
                .HasMaxLength(55);

            builder.HasMany(p => p.Childrens)
                 .WithMany(s => s.Parents)
                 .UsingEntity(j => j.ToTable("ParentsChildrens"));

            builder.HasIndex(p => new { p.LastName, p.FirstName, p.DateOfBirth })
                .IsUnique();
        }
    }
}
