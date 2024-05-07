namespace EduVerse.API.Data.EntityConfigurations
{
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(t => t.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(12)
                .IsFixedLength();

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(t => t.Education)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(t => t.Position)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(t => t.PictureFileName)
                .IsRequired(false)
                .HasMaxLength(55);

            builder.HasMany(t => t.Lessons)
                .WithMany(l => l.Teachers)
                .UsingEntity(j => j.ToTable("TeacherLessons"));

            builder.HasIndex(t => new { t.LastName, t.FirstName, t.DateOfBirth })
                .IsUnique();

            builder.HasIndex(t => t.PhoneNumber)
                .IsUnique();
        }
    }
}
