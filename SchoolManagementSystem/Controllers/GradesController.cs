using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.Grade;
using SchoolManagementSystem.Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradesController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradesController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        // GET: api/Grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetAll()
        {
            var grades = await _gradeService.GetAllGradesAsync();
            return Ok(grades);
        }

        // GET: api/Grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetById(int id)
        {
            try
            {
                var grade = await _gradeService.GetGradeByIdAsync(id);
                return Ok(grade);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Grades
        [HttpPost]
        public async Task<ActionResult<GradeDto>> Create([FromBody] CreateGradeDto gradeDto)
        {
            var createdGrade = await _gradeService.CreateGradeAsync(gradeDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGrade.Id }, createdGrade);
        }

        // PUT: api/Grades/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GradeDto>> Update(int id, [FromBody] UpdateGradeDto gradeDto)
        {
            try
            {
                var updatedGrade = await _gradeService.UpdateGradeAsync(id, gradeDto);
                return Ok(updatedGrade);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _gradeService.DeleteGradeAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Grades/student/5
        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetByStudent(int studentId)
        {
            var grades = await _gradeService.GetGradesByStudentAsync(studentId);
            return Ok(grades);
        }

        // GET: api/Grades/subject/5
        [HttpGet("subject/{subjectId}")]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetBySubject(int subjectId)
        {
            var grades = await _gradeService.GetGradesBySubjectAsync(subjectId);
            return Ok(grades);
        }
    }
}
