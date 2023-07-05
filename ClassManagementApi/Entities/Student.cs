using ClassManagement.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Api.Entities
{
    public class Student : BaseEntity
    {
        [Required]
        public string? StudentNumber { get; set; }
    }
}


//Students need to save the following:
//● National ID Number - required field
//● Name - required field
//● Surname - required field
//● Date of Birth - their age may not be more than 22
//● Student Number - required field