using Project_API.Application.Interfaces.Repositories;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.Entities;
using Project_API.Infraestructure.Repositories;

namespace Project_API.Application.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        /// <summary>
        /// Referencia al TipoDocumento Repositorio
        /// </summary>
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        /// <summary>
        /// Constructor de TipoDocumentoService para inicializar la variable tipoDocumentoRepository
        /// </summary>
        /// <param name="tipoDocumentoRepository"></param>
        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        /// <summary>
        /// Metodo para obtener todos los tipos de documento
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<TipoDocumento>> GetAllAsync()
        {
            try
            {
                return await _tipoDocumentoRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener los tipos de documentos.", ex);
            }
        }

        /// <summary>
        /// Metodo para obtener un tipo de documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <exception cref="ApplicationException"></exception>
        public async Task<TipoDocumento> GetByIdAsync(int id)
        {
            try
            {
                return await _tipoDocumentoRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Tipo de documento no encontrado.");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al obtener el tipo de documento.", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar un tipo de documento
        /// </summary>
        /// <param name="tipoDocumento"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<TipoDocumento> AddAsync(TipoDocumento tipoDocumento)
        {
            try
            {
                await _tipoDocumentoRepository.AddAsync(tipoDocumento);
                return tipoDocumento;
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
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> UpdateAsync(TipoDocumento tipoDocumento)
        {
            try
            {
                return await _tipoDocumentoRepository.UpdateAsync(tipoDocumento);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al actualizar el tipo de documento.", ex);
            }
        }

        /// <summary>
        /// Metodo para eliminar un tipo de documento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _tipoDocumentoRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al eliminar el tipo de documento.", ex);
            }
        }
    }
}
