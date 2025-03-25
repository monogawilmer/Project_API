using AutoMapper;
using Project_API.Application.Interfaces.Repositories;
using Project_API.Application.Interfaces.Services;
using Project_API.Domain.DTOs;
using Project_API.Domain.Entities;

namespace Project_API.Application.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        /// <summary>
        /// Repositorio para operaciones de tipos de documento
        /// </summary>
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;

        /// <summary>
        /// Servicio de mapeo para convertir entidades y DTOs
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Inicializa el TipoDocumentoService con sus dependencias
        /// </summary>
        /// <param name="tipoDocumentoRepository"></param>
        public TipoDocumentoService(IMapper mapper, ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _mapper = mapper;
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        /// <summary>
        /// Metodo para obtener todos los tipos de documento
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<TipoDocumentoDTO>> GetAllAsync()
        {
            try
            {
                List<TipoDocumento> tipoDocumentos = await _tipoDocumentoRepository.GetAllAsync();
                return _mapper.Map<List<TipoDocumentoDTO>>(tipoDocumentos);
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
        public async Task<TipoDocumentoDTO> GetByIdAsync(int id)
        {
            try
            {
                TipoDocumento tipoDocumento = await _tipoDocumentoRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Tipo de documento no encontrado.");
                return _mapper.Map<TipoDocumentoDTO>(tipoDocumento);
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
        public async Task<TipoDocumentoDTO> AddAsync(TipoDocumento tipoDocumento)
        {
            try
            {
                await _tipoDocumentoRepository.AddAsync(tipoDocumento);
                return _mapper.Map<TipoDocumentoDTO>(tipoDocumento);
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
