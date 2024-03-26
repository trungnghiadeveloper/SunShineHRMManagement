using HRMManagement.Models;

namespace HRMManagement.Repositories
{
    public interface IPhongBan
    {
        Task<IEnumerable<Phongban>> GetAllAsync();
        Task<Phongban> GetByIdAsync(int id);
    }
}
