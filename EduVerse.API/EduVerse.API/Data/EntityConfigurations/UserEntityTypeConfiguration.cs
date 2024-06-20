namespace EduVerse.API.Data.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(55);

            builder.HasOne(u => u.Student)
            .WithOne(s => s.User)
            .HasForeignKey<StudentEntity>(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Parent)
                .WithOne(s => s.User)
                .HasForeignKey<ParentEntity>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Teacher)
                .WithOne(s => s.User)
                .HasForeignKey<TeacherEntity>(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(u => u.UserName)
                .IsUnique();
        }
    }
}
