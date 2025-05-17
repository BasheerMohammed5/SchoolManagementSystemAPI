using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Grade
{
    public class CreateGradeDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Score { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
