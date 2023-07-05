using Classmanagement.Repository.Interfaces;
using Classmanagement.Repository.Repositories;
using ClassManagement.Api.DTOs;
using ClassManagement.Api.DTOs.Students.RequestDto;
using ClassManagement.Api.DTOs.Teachers.RequestDto;
using ClassManagement.Api.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var teachers = await _studentRepository.GetAll();
                return Ok(new ApiResponse
                {
                    Message = "successful",
                    Success = true,
                    Payload = teachers.ToList()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
                throw;
            }
        }


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            try
            {
                var teacher = await _studentRepository.GetById(id);
                return Ok(new ApiResponse
                {
                    Message = "successful",
                    Success = true,
                    Payload = teacher
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
                throw;
            }
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddStudent([FromBody] StudentRequestDto studentRequestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException();
                var checkAge = Utils.IsOver22(studentRequestDto.DOB);
                if (checkAge == false)
                {
                    return BadRequest(new ApiResponse
                    {
                        Success = false,
                        Message = "this teacher is underage"
                    });
                }
                var newTeacher = CustomMappers.CreateNewStudent(studentRequestDto);
                await _studentRepository.Add(newTeacher);

                return Ok(new ApiResponse
                {
                    Success = true,
                    Message = "Successful",
                    Payload = newTeacher
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse
                {
                    Message = ex.Message,
                    Success = false,
                });
                throw;
                throw;
            }
        }
    }
}
