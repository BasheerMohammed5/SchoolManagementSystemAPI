using System;
using System.Threading.Tasks;
using SchoolManagementSystem.Application.DTOs.Auth;
using SchoolManagementSystem.Application.Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Enums;

// No changes to the rest of the file as the issue is likely due to a missing using directive.
using SchoolManagementSystem.Application;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using SchoolManagementSystem.Application.DTOs;


namespace SchoolManagementSystem.Infrastructure.Services
{
    /// <summary>
    /// AuthService class implements IAuthService interface for user authentication and management.
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class,  providing user management and JWT
        /// services for authentication operations.
        /// </summary>
        /// <param name="userManager">The <see cref="UserManager{TUser}"/> instance used to manage user accounts and perform user-related
        /// operations.</param>
        /// <param name="jwtService">The <see cref="IJwtService"/> instance used to generate and validate JSON Web Tokens (JWTs) for
        /// authentication.</param>
        public AuthService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }
        /// <summary>
        /// Registers a new user with the provided registration details.
        /// </summary>
        /// <param name="registerDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
                if (existingUser != null)
                    throw new Exception("Email already exists");

                var user = new ApplicationUser
                {
                    FirstName = registerDto.FirstName,
                    LastName = registerDto.LastName,
                    Email = registerDto.Email,
                    UserName = registerDto.Email,
                    Role = registerDto.Role
                };

                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                return new AuthResponse
                {
                    Token = await _jwtService.GenerateJwtToken(user),
                    User = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = user.Role
                    }
                };
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                throw new Exception($"Registration failed: {ex.Message}");
            }
        }
        /// <summary>
        /// Logs in a user with the provided login details.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> LoginAsync(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null)
                    throw new Exception("Invalid email or password");

                var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!passwordValid)
                    throw new Exception("Invalid email or password");

                return new AuthResponse
                {
                    Token = await _jwtService.GenerateJwtToken(user),
                    User = new UserDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = user.Role
                    }
                };
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                throw new Exception($"Login failed: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieves the current user's details based on the provided user ID.
        /// </summary>
        /// <param name="userId">The unique identifier of the user to retrieve.</param>
        /// <returns>A <see cref="UserDto"/> object containing the user's details, including ID, first name, last name, email,
        /// and role.</returns>
        /// <exception cref="Exception">Thrown if no user is found with the specified <paramref name="userId"/>.</exception>
        public async Task<UserDto> GetCurrentUserAsync(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new Exception("User not found");

                return new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Role = user.Role
                };
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                throw new Exception($"Failed to retrieve user: {ex.Message}");
            }
        }
        /// <summary>
        /// CHanges the password of the user with the specified user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="changePasswordDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ChangePasswordAsync(string userId, ChangePasswordDto changePasswordDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new Exception("User not found");

                var result = await _userManager.ChangePasswordAsync(
                    user,
                    changePasswordDto.CurrentPassword,
                    changePasswordDto.NewPassword);

                if (!result.Succeeded)
                    throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is set up)
                throw new Exception($"Failed to change password: {ex.Message}");
            }
        }
        /// <summary>
        /// Gets the current user based on the provided user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<UserDto> IAuthService.GetCurrentUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}