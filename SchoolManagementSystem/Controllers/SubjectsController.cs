using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.Subject;
using SchoolManagementSystem.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> GetAll()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetById(int id)
        {
            try
            {
                var subject = await _subjectService.GetSubjectByIdAsync(id);
                return Ok(subject);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Subjects/by-teacher/3
        [HttpGet("by-teacher/{teacherId}")]
        public async Task<ActionResult<List<SubjectDto>>> GetByTeacher(int teacherId)
        {
            var subjects = await _subjectService.GetSubjectsByTeacherAsync(teacherId);
            return Ok(subjects);
        }

        // POST: api/Subjects
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> Create([FromBody] CreateSubjectDto subjectDto)
        {
            var createdSubject = await _subjectService.CreateSubjectAsync(subjectDto);
            return CreatedAtAction(nameof(GetById), new { id = createdSubject.Id }, createdSubject);
        }

        // PUT: api/Subjects/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SubjectDto>> Update(int id, [FromBody] UpdateSubjectDto subjectDto)
        {
            try
            {
                var updatedSubject = await _subjectService.UpdateSubjectAsync(id, subjectDto);
                return Ok(updatedSubject);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _subjectService.DeleteSubjectAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
