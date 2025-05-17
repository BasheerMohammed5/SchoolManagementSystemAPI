using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Grade
{
    public class UpdateGradeDto
    {
        public int? StudentId { get; set; }
        public int? SubjectId { get; set; }

        [Range(0, 100)]
        public decimal? Score { get; set; }

        public DateTime? Date { get; set; }
    }
}
