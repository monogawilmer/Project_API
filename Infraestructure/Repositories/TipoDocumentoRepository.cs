using Project_API.Application.Interfaces;
using Project_API.Domain.Entities;

namespace Project_API.Infraestructure.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        public async Task<List<TipoDocumento>> GetAll()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ApplicationException("", ex);
            }
        }

        public async Task<TipoDocumento?> GetById(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ApplicationException("", ex);
            }
        }

        public async Task Add(TipoDocumento tipoDocumento)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ApplicationException("", ex);
            }
        }

        public async Task Update(TipoDocumento tipoDocumento)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ApplicationException("", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new ApplicationException("", ex);
            }
        }
    }
}
