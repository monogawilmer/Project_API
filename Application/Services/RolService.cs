using AutoMapper;
using Project_API.Application.Interfaces.Repositories;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Services
{
    public class RolService : IRolService
    {
        /// <summary>
        /// Repositorio para operaciones de rol
        /// </summary>
        private readonly IRolRepository _rolRepository;

        /// <summary>
        /// Servicio de mapeo para convertir entidades y DTOs
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa el RolService con sus dependencias
        /// </summary>
        /// <param name="rolRepository"></param>
        public RolService(IMapper mapper, IRolRepository rolRepository)
        {
            _mapper =  mapper;
            _rolRepository = rolRepository;
        }

        /// <summary>
        /// Metodo para obtener todos los roles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<RolDTO>> GetAllAsync()
        {
            try
            {
                List<Rol> rols = await _rolRepository.GetAllAsync();
                return _mapper.Map<List<RolDTO>>(rols);
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
        public async Task<RolDTO> GetByIdAsync(int id)
        {
            try
            {
                Rol rol = await _rolRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Rol no encontrado.");
                return _mapper.Map<RolDTO>(rol);
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
        public async Task<RolDTO> AddAsync(Rol rol)
        {
            try
            {
                await _rolRepository.AddAsync(rol);
                return _mapper.Map<RolDTO>(rol);
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
