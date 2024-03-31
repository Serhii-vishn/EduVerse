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
                .HasMaxLength(30);

            builder.HasOne(a => a.Student)
                .WithMany(s => s.Attendance)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.ScheduleLesson)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.ScheduleLessonId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
