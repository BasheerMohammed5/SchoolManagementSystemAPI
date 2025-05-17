using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.Class;
using SchoolManagementSystem.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // تأكد من حماية الـ endpoints بالـ JWT
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Classes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAll()
        {
            var classes = await _classService.GetAllClassesAsync();
            return Ok(classes);
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetById(int id)
        {
            try
            {
                var classItem = await _classService.GetClassByIdAsync(id);
                return Ok(classItem);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Classes
        [HttpPost]
        public async Task<ActionResult<ClassDto>> Create([FromBody] CreateClassDto classDto)
        {
            var createdClass = await _classService.CreateClassAsync(classDto);
            return CreatedAtAction(nameof(GetById), new { id = createdClass.Id }, createdClass);
        }

        // PUT: api/Classes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ClassDto>> Update(int id, [FromBody] UpdateClassDto classDto)
        {
            try
            {
                var updatedClass = await _classService.UpdateClassAsync(id, classDto);
                return Ok(updatedClass);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _classService.DeleteClassAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
