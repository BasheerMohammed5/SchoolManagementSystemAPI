using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.DTOs.Class;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;  
using System.Threading.Tasks;
using SchoolManagementSystem.Infrastructure.Data; 


namespace SchoolManagementSystem.Application.Services
{
    public class ClassService : IClassService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClassService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClassDto>> GetAllClassesAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            return _mapper.Map<List<ClassDto>>(classes);
        }

        public async Task<ClassDto> GetClassByIdAsync(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
                throw new KeyNotFoundException("Class not found");

            return _mapper.Map<ClassDto>(classEntity);
        }

        public async Task<ClassDto> CreateClassAsync(CreateClassDto classDto)
        {
            var classEntity = _mapper.Map<Class>(classDto);
            _context.Classes.Add(classEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClassDto>(classEntity);
        }

        public async Task<ClassDto> UpdateClassAsync(int id, UpdateClassDto classDto)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
                throw new KeyNotFoundException("Class not found");

            _mapper.Map(classDto, classEntity);
            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClassDto>(classEntity);
        }

        public async Task<int> DeleteClassAsync(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);
            if (classEntity == null)
                throw new KeyNotFoundException("Class not found");

            _context.Classes.Remove(classEntity);
            return await _context.SaveChangesAsync();
        }
    }
}