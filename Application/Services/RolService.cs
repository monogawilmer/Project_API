using Project_API.Application.Interfaces.Repositories;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.Entities;
using Project_API.Infraestructure.Repositories;

namespace Project_API.Application.Services
{
    public class RolService : IRolService
    {
        /// <summary>
        /// Referencia al Rol Repositorio
        /// </summary>
        private readonly IRolRepository _rolRepository;

        /// <summary>
        /// Constructor de RolService para inicializar la variable rolRepository
        /// </summary>
        /// <param name="rolRepository"></param>
        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        /// <summary>
        /// Metodo para obtener todos los roles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Rol>> GetAllAsync()
        {
            try
            {
                return await _rolRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los roles.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Rol> GetByIdAsync(int id)
        {
            try
            {
                return await _rolRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Rol no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener el rol.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un rol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Rol> AddAsync(Rol rol)
        {
            try
            {
                await _rolRepository.AddAsync(rol);
                return rol;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar el rol.", ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar un rol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> UpdateAsync(Rol rol)
        {
            try
            {
                return await _rolRepository.UpdateAsync(rol);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar el rol.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _rolRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar el rol.", ex);
            }
        }
    }
}
