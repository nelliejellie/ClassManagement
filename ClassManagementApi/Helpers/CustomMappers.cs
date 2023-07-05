using ClassManagement.Api.DTOs.Students.RequestDto;
using ClassManagement.Api.DTOs.Teachers.RequestDto;
using ClassManagement.Api.Entities;

namespace ClassManagement.Api.Helpers
{
    public static class CustomMappers
    {
        public static Teacher CreateNewTeacher(TeacherRequestDto teacherRequest)
        {
            Teacher teacher = new Teacher
            {
                NIN = teacherRequest.NIN,
                Name = teacherRequest.Name,
                Surname = teacherRequest.Surname,
                DOB = teacherRequest.DOB.ToString(),
                TeacherNumber = teacherRequest.TeacherNumber,
                Salary = teacherRequest.Salary,
                Title = teacherRequest.Title,
                UpdatedAt = DateTime.UtcNow.ToString()
            };

            return teacher;
        }

        public static Student CreateNewStudent(StudentRequestDto studentRequest)
        {
            Student student = new Student
            {
                NIN = studentRequest.NIN,
                Name = studentRequest.Name,
                Surname = studentRequest.Surname,
                DOB = studentRequest.DOB.ToString(),
                StudentNumber = studentRequest.StudentNumber,
                UpdatedAt = DateTime.UtcNow.ToString()
            };

            return student;
        }
    }
}
