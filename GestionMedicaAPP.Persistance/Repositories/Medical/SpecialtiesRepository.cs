using GestionMedicaAPP.Domain.Entities.Medical;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Medical;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Medical
{
    public class SpecialtiesRepository(GestionMedicaContext context, ILogger<SpecialtiesRepository> logger) : BaseRepository<Specialties>(context), ISpecialtiesRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<SpecialtiesRepository> _logger = logger;

        public async override Task<OperationResult> Save(Specialties entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La especialidad no puede ser nula.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando la especialidad.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(Specialties entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "La especialidad no puede ser nula.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando la especialidad.";
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
                result.Data = await (from specialties in _context.Specialties
                                     where specialties.IsActive == true
                                     select new SpecialtiesModel() 
                                     {
                                         SpecialtyID = specialties.SpecialtyID,
                                         SpecialtyName = specialties.SpecialtyName,
                                         CreatedAt = specialties.CreatedAt,
                                         UpdatedAt = specialties.UpdatedAt,
                                         IsActive = specialties.IsActive
                                     })
                    .AsNoTracking()
                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo las especialidades.";
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
                var specialty = await _context.Specialties
                    .AsNoTracking()
                    .FirstOrDefaultAsync(s => s.SpecialtyID == id);

                if (specialty == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró la especialidad.";
                    return result;
                }

                result.Data = specialty;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo la especialidad.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}