using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Subject;
using SchoolManagementSystem.Application.DTOs.Teacher;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TeacherService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TeacherDto>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return _mapper.Map<List<TeacherDto>>(teachers);
        }

        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<TeacherDto> CreateTeacherAsync(CreateTeacherDto teacherDto)
        {
            var teacher = _mapper.Map<Teacher>(teacherDto);
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<TeacherDto> UpdateTeacherAsync(int id, UpdateTeacherDto teacherDto)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            _mapper.Map(teacherDto, teacher);
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();

            return _mapper.Map<TeacherDto>(teacher);
        }

        public async Task<int> DeleteTeacherAsync(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                throw new Exception("Teacher not found");

            _context.Teachers.Remove(teacher);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<SubjectDto>> GetTeacherSubjectsAsync(int teacherId)
        {
            var subjects = await _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .ToListAsync();

            return _mapper.Map<List<SubjectDto>>(subjects);
        }
    }
}