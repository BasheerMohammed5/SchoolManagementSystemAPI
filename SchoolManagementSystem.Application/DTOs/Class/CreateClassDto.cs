using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Class
{
    public class CreateClassDto
    {
        [Required]
        public string Name { get; set; }

        public string RoomNumber { get; set; }
    }
}
