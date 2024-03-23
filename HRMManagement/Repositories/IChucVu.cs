using HRMManagement.Models;

namespace HRMManagement.Repositories
{
    public interface IChucVu
    {
        Task<IEnumerable<Chucvu>> GetAllAsync();
        Task<Chucvu> GetByIdAsync(int id);
    }
}
