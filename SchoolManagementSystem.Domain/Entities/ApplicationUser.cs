using Microsoft.AspNetCore.Identity;
using SchoolManagementSystem.Domain.Enums;

namespace SchoolManagementSystem.Domain.Entities
{
    // هذا الكلاس يمثل المستخدم في قاعدة البيانات
    public class ApplicationUser : IdentityUser
    {
        // الاسم الأول للمستخدم
        public string FirstName { get; set; }

        // الاسم الأخير للمستخدم
        public string LastName { get; set; }

        // الدور (Admin, Teacher, Student, إلخ)
        public Role Role { get; set; }

        
    }
}
