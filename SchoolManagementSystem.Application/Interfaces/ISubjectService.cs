using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Subject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<SubjectDto> CreateSubjectAsync(CreateSubjectDto subjectDto);
        Task<SubjectDto> UpdateSubjectAsync(int id, UpdateSubjectDto subjectDto);
        Task<int> DeleteSubjectAsync(int id);
        Task<List<SubjectDto>> GetSubjectsByTeacherAsync(int teacherId);
    }
}