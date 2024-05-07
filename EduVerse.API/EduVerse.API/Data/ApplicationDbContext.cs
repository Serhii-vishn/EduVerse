namespace EduVerse.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<ParentEntity> Parents { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<ScheduleEntity> Schedules { get; set; }
        public DbSet<AttendanceEntity> Attendances { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ParentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GroupEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LessonEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AttendanceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new GradeEntityTypeConfiguration());

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Name = "Teacher",
                    NormalizedName = "Teacher".ToUpper()
                },
                new IdentityRole
                {
                    Name = "Parent",
                    NormalizedName = "Parent".ToUpper()
                },
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
