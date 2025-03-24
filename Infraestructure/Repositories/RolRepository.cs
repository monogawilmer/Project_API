using Microsoft.EntityFrameworkCore;
using Project_API.Application.Interfaces.Repositories;
using Project_API.Domain.Entities;
using Project_API.Infraestructure.Data;

namespace Project_API.Infraestructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        /// <summary>
        /// Referencia DbContext
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor de RolRepository para inicializar la variable context
        /// </summary>
        /// <param name="context"></param>
        public RolRepository(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Metodo para obtener todos los roles
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Rol>> GetAll()
        {
            try
            {
                return await _context.Rols.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener los roles.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un rol por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Rol?> GetById(int id)
        {
            try
            {
                return await _context.Rols.FindAsync(id) ?? throw new KeyNotFoundException($"Rol con ID {id} no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el rol con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un rol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task Add(Rol rol)
        {
            try
            {
                _context.Rols.Add(rol);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al agregar el rol.", ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar un rol
        /// </summary>
        /// <param name="rol"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task Update(Rol rol)
        {
            try
            {
                if (!await _context.Rols.AnyAsync(x => x.Id == rol.Id))
                    throw new KeyNotFoundException($"Rol con ID {rol.Id} no encontrado.");

                _context.Rols.Update(rol);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el rol con ID {rol.Id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un rol
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task Delete(int id)
        {
            try
            {
                Rol rol = await _context.Rols.FindAsync(id) ?? throw new KeyNotFoundException($"Rol con ID {id} no encontrado.");

                _context.Rols.Remove(rol);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el rol con ID{id}.", ex);
            }
        }
    }
}
