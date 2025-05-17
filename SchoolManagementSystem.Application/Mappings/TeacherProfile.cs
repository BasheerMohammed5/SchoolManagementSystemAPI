using AutoMapper;
using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Teacher;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Mappings
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            // Mapping configuration for Teacher
            CreateMap<Teacher, TeacherDto>();
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();

            // Add more mappings as needed
        }
    }
}