using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Subject
{
    public class CreateSubjectDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}
