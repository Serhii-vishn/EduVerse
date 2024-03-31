namespace EduVerse.API.Data.EntityConfigurations
{
    public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.ToTable("Lesson");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(l => l.Description)
                .IsRequired(false)
                .HasMaxLength(100);
        }
    }
}
