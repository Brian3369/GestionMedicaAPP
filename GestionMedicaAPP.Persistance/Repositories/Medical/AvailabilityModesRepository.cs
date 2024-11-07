using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public class AvailabilityModesRepository(GestionMedicaContext context, ILogger<AvailabilityModesRepository> logger) : BaseRepository<AvailabilityModes>(context), IAvailabilityModesRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<AvailabilityModesRepository> _logger = logger;

        public async override Task<OperationResult> Save(AvailabilityModes entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El modo de disponibilidad no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el modo de disponibilidad.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(AvailabilityModes entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El modo de disponibilidad no puede ser nulo.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el modo de disponibilidad.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<OperationResult> Getall()
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await _context.AvailabilityModes
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los modos de disponibilidad.";
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
                var availabilityMode = await _context.AvailabilityModes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(am => am.SAvailabilityModeID == id);

                if (availabilityMode == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el modo de disponibilidad.";
                    return result;
                }

                result.Data = availabilityMode;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el modo de disponibilidad.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}