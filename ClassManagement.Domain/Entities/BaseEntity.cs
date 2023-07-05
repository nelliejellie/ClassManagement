using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Api.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = DateTime.UtcNow.ToString();
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        public string? CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
        [Required]
        public string? NIN { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Surname { get; set; }
        [Required]
        public string? DOB { get; set; }
    }
}
