﻿using Classmanagement.Repository.Interfaces;
using ClassManagement.Api.DTOs;
using ClassManagement.Api.DTOs.Teachers.RequestDto;
using ClassManagement.Api.Entities;
using ClassManagement.Api.Helpers;
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
        [Route("")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
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
        [Route("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
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

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddTeacher([FromBody]TeacherRequestDto teacherRequestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException();
                var checkAge = Utils.IsOver21(teacherRequestDto.DOB);
                if (checkAge == false)
                {
                    return BadRequest(new ApiResponse
                    {
                        Success = false,
                        Message = "this teacher is underage"
                    });
                }
                var newTeacher = CustomMappers.CreateNewTeacher(teacherRequestDto);
                await _teacherRepository.Add(newTeacher);

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
