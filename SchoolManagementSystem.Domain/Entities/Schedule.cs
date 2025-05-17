using SchoolManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
