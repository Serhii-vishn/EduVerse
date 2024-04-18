namespace EduVerse.API.Data.EntityConfigurations
{
    public class GradeEntityTypeConfiguration : IEntityTypeConfiguration<GradeEntity>
    {
        public void Configure(EntityTypeBuilder<GradeEntity> builder)
        {
            builder.ToTable("Grade");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(g => g.Mark)
                .IsRequired();

            builder.Property(a => a.Competence)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(a => a.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(a => a.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ScheduleLesson)
                .WithMany(s => s.Grades)
                .HasForeignKey(a => a.ScheduleLessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new { a.Date, a.StudentId, a.ScheduleLessonId })
                .IsUnique();
        }
    }
}
