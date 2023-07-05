using Classmanagement.Repository.Interfaces;
using ClassManagement.Api.DTOs;
using ClassManagement.Api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        [Route("teachers")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTeachers()
        {
            try
            {
                var teachers = await _teacherRepository.GetAll();
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
        [Route("teacher/{id}")]
        public async Task<IActionResult> GetTeacher([FromRoute]Guid id)
        {
            try
            {
                var teacher = await _teacherRepository.GetById(id);
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
    }
}
