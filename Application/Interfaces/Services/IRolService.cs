using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Services
{
    public interface IRolService
    {
        Task<List<RolDTO>> GetAllAsync();
        Task<RolDTO> GetByIdAsync(int id);
        Task<RolDTO> AddAsync(Rol rol);
        Task<bool> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}
