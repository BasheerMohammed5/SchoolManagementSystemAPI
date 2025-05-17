using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Application.DTOs.Teacher
{
    public class UpdateTeacherDto
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string Specialization { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}