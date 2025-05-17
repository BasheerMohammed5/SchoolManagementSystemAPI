using SchoolManagementSystem.Application.DTOs;
using SchoolManagementSystem.Application.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponse> LoginAsync(LoginDto loginDto);
        Task<UserDto> GetCurrentUserAsync(string userId);
        Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto);
    }
}

