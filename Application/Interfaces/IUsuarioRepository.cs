using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAll();
        Task<Usuario?> GetById(int id);
        Task Add(Usuario usuario);
        Task Update(Usuario usuario);
        Task Delete(int id);
    }
}
