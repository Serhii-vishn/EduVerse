namespace EduVerse.API.Data.EntityConfigurations
{
    public class ScheduleEntityTypeConfiguration : IEntityTypeConfiguration<ScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<ScheduleEntity> builder)
        {
            builder.ToTable("Schedules");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(s => s.LessonTheme)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(s => s.DayOfWeek)
                .IsRequired()
                .HasMaxLength(3);

            builder.Property(s => s.Time)
                .IsRequired()
                .HasColumnType("time");

            builder.HasOne(s => s.Lesson)
                .WithMany(l => l.ScheduleLessons)
                .HasForeignKey(s => s.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Teacher)
                .WithMany(t => t.ScheduledClasses)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Group)
                .WithMany(g => g.GroupSchedule)
                .HasForeignKey(s => s.GroupId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(s => new { s.DayOfWeek, s.Time, s.GroupId })
                .IsUnique();
        }
    }
}
