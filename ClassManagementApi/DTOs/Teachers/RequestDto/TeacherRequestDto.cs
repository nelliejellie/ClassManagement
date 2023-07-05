using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Api.DTOs.Teachers.RequestDto
{
    public class TeacherRequestDto
    {
        public string? NIN { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public Decimal? Salary { get; set; }
        [Required]
        public string? TeacherNumber { get; set; }
    }
}
