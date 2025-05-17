using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Grade
{
    // GradeDto.cs
    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal Score { get; set; }
        public DateTime Date { get; set; }
    }
}
