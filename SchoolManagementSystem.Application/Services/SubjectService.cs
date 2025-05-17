using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs.Subject;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SubjectDto>> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects
                .Include(s => s.Teacher)
                .ToListAsync();

            return _mapper.Map<List<SubjectDto>>(subjects);
        }

        public async Task<SubjectDto> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .Include(s => s.Teacher)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
                throw new KeyNotFoundException("Subject not found");

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task<SubjectDto> CreateSubjectAsync(CreateSubjectDto subjectDto)
        {
            var subject = _mapper.Map<Subject>(subjectDto);
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task<SubjectDto> UpdateSubjectAsync(int id, UpdateSubjectDto subjectDto)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                throw new KeyNotFoundException("Subject not found");

            _mapper.Map(subjectDto, subject);
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();

            return _mapper.Map<SubjectDto>(subject);
        }

        public async Task<int> DeleteSubjectAsync(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                throw new KeyNotFoundException("Subject not found");

            _context.Subjects.Remove(subject);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SubjectDto>> GetSubjectsByTeacherAsync(int teacherId)
        {
            var subjects = await _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .Include(s => s.Teacher)
                .ToListAsync();

            return _mapper.Map<List<SubjectDto>>(subjects);
        }
    }
}