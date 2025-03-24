using Project_API.Application.Interfaces.Repositories;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.Entities;

namespace Project_API.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Referencia al Usuario Repositorio
        /// </summary>
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Constructor de UsuarioService para inicializar la variable usuarioRepository
        /// </summary>
        /// <param name="usuarioRepository"></param>
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Metodo para obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Usuario>> GetAllAsync()
        {
            try
            {
                return await _usuarioRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los usuarios.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Usuario> GetByIdAsync(int id)
        {
            try
            {
                return await _usuarioRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Usuario no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener el usuario.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            try
            {
                await _usuarioRepository.AddAsync(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar el usuario.", ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            try
            {
                return await _usuarioRepository.UpdateAsync(usuario);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar el usuario.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _usuarioRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar el usuario.", ex);
            }
        }
    }
}
