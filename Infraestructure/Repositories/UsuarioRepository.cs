﻿using Microsoft.EntityFrameworkCore;
using Project_API.Application.Interfaces.Repositories;
using Project_API.Domain.Entities;
using Project_API.Infraestructure.Data;

namespace Project_API.Infraestructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Referencia DbContext
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor de UsuarioRepository para inicializar la variable context
        /// </summary>
        /// <param name="context"></param>
        public UsuarioRepository(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Metodo para obtener todos los usuarios
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<Usuario>> GetAllAsync()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los usuarios.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<Usuario?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Usuarios.FindAsync(id) ?? throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el usuario con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task AddAsync(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al agregar el usuario.", ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar un usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            try
            {
                if (!await _context.Usuarios.AnyAsync(x => x.Id == usuario.Id))
                    throw new KeyNotFoundException($"Usuario con ID {usuario.Id} no encontrado.");

                _context.Usuarios.Update(usuario);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el usuario con ID {usuario.Id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Usuario usuario = await _context.Usuarios.FindAsync(id) ?? throw new KeyNotFoundException($"Usuario con ID {id} no encontrado.");

                _context.Usuarios.Remove(usuario);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el usuario con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un Usuario por su correo
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            try
            {
                return await _context.Usuarios.Include(x => x.Rol).FirstOrDefaultAsync(u => u.Correo == email) ?? throw new KeyNotFoundException($"Usuario con email {email} no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el usuario con email {email}.", ex);
            }
        }
    }
}
