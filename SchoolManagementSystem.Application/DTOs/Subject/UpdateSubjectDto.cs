using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Subject
{
    public class UpdateSubjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
    }
}
