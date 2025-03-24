using Project_API.Domain.Entities;

namespace Project_API.Application.Interfaces.Repositories
{
    public interface IRolRepository
    {
        Task<List<Rol>> GetAll();
        Task<Rol?> GetById(int id);
        Task Add(Rol rol);
        Task Update(Rol rol);
        Task Delete(int id);
    }
}
