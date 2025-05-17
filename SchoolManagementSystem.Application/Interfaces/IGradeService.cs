using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Grade;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IGradeService
    {
        Task<List<GradeDto>> GetAllGradesAsync();
        Task<GradeDto> GetGradeByIdAsync(int id);
        Task<GradeDto> CreateGradeAsync(CreateGradeDto gradeDto);
        Task<GradeDto> UpdateGradeAsync(int id, UpdateGradeDto gradeDto);
        Task<int> DeleteGradeAsync(int id);
        Task<List<GradeDto>> GetGradesByStudentAsync(int studentId);
        Task<List<GradeDto>> GetGradesBySubjectAsync(int subjectId);
    }
}