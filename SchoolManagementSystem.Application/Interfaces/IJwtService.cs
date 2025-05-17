using SchoolManagementSystem.Domain.Entities;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Interfaces
{
    public interface IJwtService
    {
        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}