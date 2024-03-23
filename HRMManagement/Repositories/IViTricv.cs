using HRMManagement.Models;

namespace HRMManagement.Repositories
{
    public interface IViTricv
    {
        Task<IEnumerable<Vitricv>> GetAllAsync();
        Task<Vitricv> GetByIdAsync(int id);
    }
}
