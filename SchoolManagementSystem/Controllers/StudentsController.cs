using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.Student;
using SchoolManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAll()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            try
            {
                var student = await _studentService.GetStudentByIdAsync(id);
                return Ok(student);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Students/by-class/3
        [HttpGet("by-class/{classId}")]
        public async Task<ActionResult<List<StudentDto>>> GetByClass(int classId)
        {
            try
            {
                var students = await _studentService.GetStudentsByClassAsync(classId);
                return Ok(students);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Students
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create([FromBody] CreateStudentDto studentDto)
        {
            var createdStudent = await _studentService.CreateStudentAsync(studentDto);
            return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentDto>> Update(int id, [FromBody] UpdateStudentDto studentDto)
        {
            try
            {
                var updatedStudent = await _studentService.UpdateStudentAsync(id, studentDto);
                return Ok(updatedStudent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _studentService.DeleteStudentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
