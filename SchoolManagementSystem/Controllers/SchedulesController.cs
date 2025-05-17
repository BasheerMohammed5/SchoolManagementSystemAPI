using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Application.DTOs.Schedule;
using SchoolManagementSystem.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // تأكد من تفعيل JWT Authentication
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _scheduleService.GetAllSchedulesAsync();
            return Ok(result);
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _scheduleService.GetScheduleByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Schedules/by-class/3
        [HttpGet("by-class/{classId}")]
        public async Task<IActionResult> GetByClass(int classId)
        {
            var result = await _scheduleService.GetSchedulesByClassAsync(classId);
            return Ok(result);
        }

        // GET: api/Schedules/by-teacher/4
        [HttpGet("by-teacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacher(int teacherId)
        {
            var result = await _scheduleService.GetSchedulesByTeacherAsync(teacherId);
            return Ok(result);
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateScheduleDto dto)
        {
            var result = await _scheduleService.CreateScheduleAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // PUT: api/Schedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateScheduleDto dto)
        {
            try
            {
                var result = await _scheduleService.UpdateScheduleAsync(id, dto);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _scheduleService.DeleteScheduleAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
