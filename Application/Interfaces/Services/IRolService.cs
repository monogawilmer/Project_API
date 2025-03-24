using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Services
{
    public interface IRolService
    {
        Task<List<Rol>> GetAllAsync();
        Task<Rol> GetByIdAsync(int id);
        Task<Rol> AddAsync(Rol rol);
        Task<bool> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}
