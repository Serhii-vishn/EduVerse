namespace EduVerse.API.Models.DTO
{
    public class StudentAttedanceDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public IList<AttendanceListDTO> Attendances { get; set; } = new List<AttendanceListDTO>();
    }
}
