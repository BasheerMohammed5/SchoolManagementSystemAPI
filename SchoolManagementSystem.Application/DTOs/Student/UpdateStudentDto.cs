using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Application.DTOs.Student
{
    public class UpdateStudentDto
    {
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public int? ClassId { get; set; }
    }
}