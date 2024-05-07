namespace EduVerse.API.Data.EntityConfigurations
{
    public class GroupEntityTypeConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.ToTable("Groups");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(g => g.Curator)
                .WithMany(t => t.Groups)
                .HasForeignKey(g => g.CuratorId)
                .IsRequired();

            builder.HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            builder.HasMany(g => g.Lessons)
                .WithMany(l => l.Groups)
                .UsingEntity(j => j.ToTable("GroupLessons"));

            builder.HasIndex(g => g.GroupName)
                .IsUnique();
        }
    }
}
