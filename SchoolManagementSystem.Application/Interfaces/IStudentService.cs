using SchoolManagementSystem.Application.DTOs.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<StudentDto> CreateStudentAsync(CreateStudentDto studentDto);
        Task<StudentDto> UpdateStudentAsync(int id, UpdateStudentDto studentDto);
        Task<int> DeleteStudentAsync(int id);
        Task<List<StudentDto>> GetStudentsByClassAsync(int classId);
    }
}
