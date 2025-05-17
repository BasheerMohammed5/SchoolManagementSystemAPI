using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.DTOs.Auth
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public UserDto User { get; set; }
    }
}
