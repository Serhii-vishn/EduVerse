namespace EduVerse.API.Data.EntityConfigurations
{
    public class AttendanceEntityTypeConfiguration : IEntityTypeConfiguration<AttendanceEntity>
    {
        public void Configure(EntityTypeBuilder<AttendanceEntity> builder)
        {
            builder.ToTable("Attendance");

            builder.HasKey(a => a.Id);

            builder.Property(s => s.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(a => a.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(a => a.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(a => a.Student)
                .WithMany(s => s.Attendance)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ScheduleLesson)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.ScheduleLessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(a => new { a.Date, a.StudentId, a.ScheduleLessonId })
                .IsUnique();
        }
    }
}
