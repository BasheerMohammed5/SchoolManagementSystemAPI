using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Schedule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAllSchedulesAsync();
        Task<ScheduleDto> GetScheduleByIdAsync(int id);
        Task<ScheduleDto> CreateScheduleAsync(CreateScheduleDto scheduleDto);
        Task<ScheduleDto> UpdateScheduleAsync(int id, UpdateScheduleDto scheduleDto);
        Task<int> DeleteScheduleAsync(int id);
        Task<List<ScheduleDto>> GetSchedulesByClassAsync(int classId);
        Task<List<ScheduleDto>> GetSchedulesByTeacherAsync(int teacherId);
    }
}