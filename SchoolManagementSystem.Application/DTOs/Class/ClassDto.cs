using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Class
{
    // ClassDto.cs
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public int StudentCount { get; set; }
    }
}
