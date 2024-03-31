namespace EduVerse.API.Data.EntityConfigurations
{
    public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.ToTable("Teacher");

            builder.HasKey(t => t.Id);

            builder.Property(u => u.Id)
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

            builder.HasIndex(t => new { t.LastName, t.FirstName, t.DateOfBirth })
                .IsUnique();

            builder.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13)
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

            builder.Property(t => t.GroupId)
                .IsRequired(false);

            builder.HasOne(t => t.Group)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder.HasMany(t => t.Lessons)
                .WithMany(l => l.Teachers)
                .UsingEntity(j => j.ToTable("TeacherLessons"));
        }
    }
}
