using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Subject;
using SchoolManagementSystem.Application.DTOs.Teacher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDto>> GetAllTeachersAsync();
        Task<TeacherDto> GetTeacherByIdAsync(int id);
        Task<TeacherDto> CreateTeacherAsync(CreateTeacherDto teacherDto);
        Task<TeacherDto> UpdateTeacherAsync(int id, UpdateTeacherDto teacherDto);
        Task<int> DeleteTeacherAsync(int id);
        Task<List<SubjectDto>> GetTeacherSubjectsAsync(int teacherId);
    }
}