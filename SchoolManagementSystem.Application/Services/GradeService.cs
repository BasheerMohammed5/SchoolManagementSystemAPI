using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs.Grade;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GradeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GradeDto>> GetAllGradesAsync()
        {
            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .ToListAsync();

            return _mapper.Map<List<GradeDto>>(grades);
        }

        public async Task<GradeDto> GetGradeByIdAsync(int id)
        {
            var grade = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null)
                throw new KeyNotFoundException("Grade not found");

            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<GradeDto> CreateGradeAsync(CreateGradeDto gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<GradeDto> UpdateGradeAsync(int id, UpdateGradeDto gradeDto)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                throw new KeyNotFoundException("Grade not found");

            _mapper.Map(gradeDto, grade);
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();

            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<int> DeleteGradeAsync(int id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                throw new KeyNotFoundException("Grade not found");

            _context.Grades.Remove(grade);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<GradeDto>> GetGradesByStudentAsync(int studentId)
        {
            var grades = await _context.Grades
                .Where(g => g.StudentId == studentId)
                .Include(g => g.Subject)
                .ToListAsync();

            return _mapper.Map<List<GradeDto>>(grades);
        }

        public async Task<List<GradeDto>> GetGradesBySubjectAsync(int subjectId)
        {
            var grades = await _context.Grades
                .Where(g => g.SubjectId == subjectId)
                .Include(g => g.Student)
                .ToListAsync();

            return _mapper.Map<List<GradeDto>>(grades);
        }
    }
}