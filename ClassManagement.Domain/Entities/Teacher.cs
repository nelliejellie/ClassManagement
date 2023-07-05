using ClassManagement.Api.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Api.Entities
{
    public class Teacher : BaseEntity
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public Decimal? Salary { get; set; }
        [Required]
        public string? TeacherNumber { get; set; }
    }
}


//Teachers need to save the following details:
//● National ID number - required field
//● Title - required can be either [Mr, Mrs, Miss, Dr, Prof]
//● Name - required
//● Surname - required
//● Date of Birth - required - their age may not be less than 21
//● Teacher Number - required
//● Salary - optional