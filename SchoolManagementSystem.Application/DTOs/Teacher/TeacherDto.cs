using SchoolManagementSystem.Application.DTOs.Subject;
using System.Collections.Generic;

namespace SchoolManagementSystem.Application.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}