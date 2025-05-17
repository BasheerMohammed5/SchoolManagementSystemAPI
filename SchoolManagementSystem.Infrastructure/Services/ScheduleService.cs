using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs.Schedule;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ScheduleDto>> GetAllSchedulesAsync()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Subject)
                .Include(s => s.Class)
                .ToListAsync();

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }

        public async Task<ScheduleDto> GetScheduleByIdAsync(int id)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Subject)
                .Include(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found");

            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<ScheduleDto> CreateScheduleAsync(CreateScheduleDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<ScheduleDto> UpdateScheduleAsync(int id, UpdateScheduleDto scheduleDto)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found");

            _mapper.Map(scheduleDto, schedule);
            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();

            return _mapper.Map<ScheduleDto>(schedule);
        }

        public async Task<int> DeleteScheduleAsync(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
                throw new KeyNotFoundException("Schedule not found");

            _context.Schedules.Remove(schedule);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ScheduleDto>> GetSchedulesByClassAsync(int classId)
        {
            var schedules = await _context.Schedules
                .Where(s => s.ClassId == classId)
                .Include(s => s.Subject)
                .ToListAsync();

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }

        public async Task<List<ScheduleDto>> GetSchedulesByTeacherAsync(int teacherId)
        {
            var schedules = await _context.Schedules
                .Include(s => s.Subject)
                .Where(s => s.Subject.TeacherId == teacherId)
                .ToListAsync();

            return _mapper.Map<List<ScheduleDto>>(schedules);
        }
    }
}