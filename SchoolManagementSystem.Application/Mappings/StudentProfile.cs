using AutoMapper;
using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Student;
using SchoolManagementSystem.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolManagementSystem.Application.Mappings
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}