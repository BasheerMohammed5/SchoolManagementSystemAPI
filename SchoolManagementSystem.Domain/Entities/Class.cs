using SchoolManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Class : BaseEntity
    {
        public string Name { get; set; }
        public string RoomNumber { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
