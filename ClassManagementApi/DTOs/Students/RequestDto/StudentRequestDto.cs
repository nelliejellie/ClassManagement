using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Api.DTOs.Students.RequestDto
{
    public class StudentRequestDto
    {
        public string? NIN { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public string? StudentNumber { get; set; }
    }
}
