namespace EduVerse.API.Data.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PictureFileName { get; set; }

        public int? FatherId { get; set; }
        public ParentEntity? Father { get; set; }

        public int? MotherId { get; set; }
        public ParentEntity? Mother { get; set; }

        public int? ChildminderId { get; set; }
        public ParentEntity? Childminder { get; set; }
    }
}
