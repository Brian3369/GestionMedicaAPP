using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurance
{
    public class NetworkTypeRepository(GestionMedicaContext context, ILogger<NetworkTypeRepository> logger) : BaseRepository<NetworkType>(context), INetworkTypeRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<NetworkTypeRepository> _logger = logger;

        public async override Task<OperationResult> Save(NetworkType entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El tipo de red no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el tipo de red.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(NetworkType entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El tipo de red no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el tipo de red.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await _context.NetworkType
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los tipos de red.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> GetEntityBy(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                var networkType = await _context.NetworkType
                    .AsNoTracking()
                    .FirstOrDefaultAsync(nt => nt.NetworkTypeId == id);

                if (networkType == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el tipo de red.";
                    return result;
                }

                result.Data = networkType;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el tipo de red.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}