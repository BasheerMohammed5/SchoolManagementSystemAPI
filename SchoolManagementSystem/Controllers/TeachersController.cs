using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Subject;
using SchoolManagementSystem.Application.DTOs.Teacher;
using SchoolManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<List<TeacherDto>>> GetAll()
        {
            var teachers = await _teacherService.GetAllTeachersAsync();
            return Ok(teachers);
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetById(int id)
        {
            try
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(id);
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Teachers/5/subjects
        [HttpGet("{teacherId}/subjects")]
        public async Task<ActionResult<List<SubjectDto>>> GetTeacherSubjects(int teacherId)
        {
            var subjects = await _teacherService.GetTeacherSubjectsAsync(teacherId);
            return Ok(subjects);
        }

        // POST: api/Teachers
        [HttpPost]
        public async Task<ActionResult<TeacherDto>> Create([FromBody] CreateTeacherDto teacherDto)
        {
            var createdTeacher = await _teacherService.CreateTeacherAsync(teacherDto);
            return CreatedAtAction(nameof(GetById), new { id = createdTeacher.Id }, createdTeacher);
        }

        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<TeacherDto>> Update(int id, [FromBody] UpdateTeacherDto teacherDto)
        {
            try
            {
                var updatedTeacher = await _teacherService.UpdateTeacherAsync(id, teacherDto);
                return Ok(updatedTeacher);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _teacherService.DeleteTeacherAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
