using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<List<UsuarioDTO>> GetAllAsync();
        Task<UsuarioDTO> GetByIdAsync(int id);
        Task<UsuarioDTO> AddAsync(Usuario usuario);
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}
