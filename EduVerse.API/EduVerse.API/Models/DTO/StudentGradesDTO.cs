namespace EduVerse.API.Models.DTO
{
    public class StudentGradesDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public IList<GradeListDTO> Grades { get; set; } = new List<GradeListDTO>();
    }
}
