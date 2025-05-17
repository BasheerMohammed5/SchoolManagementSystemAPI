// SchoolManagementSystem.Domain/Common/IUnitOfWork.cs
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Common
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}