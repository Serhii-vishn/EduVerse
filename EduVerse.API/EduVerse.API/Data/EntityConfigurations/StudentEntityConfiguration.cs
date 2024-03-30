﻿namespace EduVerse.API.Data.EntityConfigurations
{
    public class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
    {
        public void Configure(EntityTypeBuilder<StudentEntity> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(s => s.Id);

            builder.Property(u => u.Id)
                .UseIdentityColumn()
                .IsRequired();

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(s => s.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.HasIndex(s => new { s.LastName, s.FirstName, s.DateOfBirth })
                .IsUnique();

            builder.Property(s => s.Gender)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(13)
                .IsFixedLength();

            builder.Property(s => s.Email)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(c => c.PictureFileName)
                .IsRequired(false)
                .HasMaxLength(55);

            builder.HasOne(s => s.Father)
                .WithMany()
                .HasForeignKey(s => s.FatherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Mother)
                .WithMany()
                .HasForeignKey(s => s.MotherId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Childminder)
                .WithMany()
                .HasForeignKey(s => s.ChildminderId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}