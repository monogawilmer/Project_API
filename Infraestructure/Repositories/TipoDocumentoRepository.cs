using Microsoft.EntityFrameworkCore;
using Project_API.Application.Interfaces.Repositories;
using Project_API.Domain.Entities;
using Project_API.Infraestructure.Data;

namespace Project_API.Infraestructure.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        /// <summary>
        /// Referencia DbContext
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor de TipoDocumentoRepository para inicializar la variable context
        /// </summary>
        /// <param name="context"></param>
        public TipoDocumentoRepository(ApplicationDbContext context) => _context = context;

        /// <summary>
        /// Metodo para obtener todos los tipos de documentos
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<TipoDocumento>> GetAll()
        {
            try
            {
                return await _context.TipoDocumentos.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los tipos de documentos.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un tipo de documento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<TipoDocumento?> GetById(int id)
        {
            try
            {
                return await _context.TipoDocumentos.FindAsync(id) ?? throw new KeyNotFoundException($"Tipo de documento con ID {id} no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al obtener el tipo de documento con ID {id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un tipo de documento
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task Add(TipoDocumento tipoDocumento)
        {
            try
            {
                _context.TipoDocumentos.Add(tipoDocumento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al agregar el tipo de documento.", ex);
            }
        }

        /// <summary>
        /// Metodo para actualizar un tipo de documento
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task Update(TipoDocumento tipoDocumento)
        {
            try
            {
                if (!await _context.TipoDocumentos.AnyAsync(x => x.Id == tipoDocumento.Id))
                    throw new KeyNotFoundException($"Tipo de documento con ID {tipoDocumento.Id} no encontrado.");

                _context.TipoDocumentos.Update(tipoDocumento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al actualizar el tipo de documento con ID {tipoDocumento.Id}.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un tipo de documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task Delete(int id)
        {
            try
            {
                TipoDocumento tipoDocumento = await _context.TipoDocumentos.FindAsync(id) ?? throw new KeyNotFoundException($"Tipo de documento con ID {id} no encontrado.");

                _context.TipoDocumentos.Remove(tipoDocumento);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error al eliminar el tipo de documento con ID {id}.", ex);
            }
        }
    }
}
