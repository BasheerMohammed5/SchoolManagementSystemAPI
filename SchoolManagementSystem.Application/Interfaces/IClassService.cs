using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Class;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassDto>> GetAllClassesAsync();
        Task<ClassDto> GetClassByIdAsync(int id);
        Task<ClassDto> CreateClassAsync(CreateClassDto classDto);
        Task<ClassDto> UpdateClassAsync(int id, UpdateClassDto classDto);
        Task<int> DeleteClassAsync(int id);
    }
}