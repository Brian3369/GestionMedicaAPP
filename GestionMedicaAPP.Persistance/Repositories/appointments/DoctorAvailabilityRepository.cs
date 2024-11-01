using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.appointmets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace GestionMedicaAPP.Persistance.Repositories.appointments
{
    public sealed class DoctorAvailabilityRepository(GestionMedicaContext context, ILogger<DoctorAvailabilityRepository> logger) : BaseRepository<DoctorAvailability>(context), IDoctorAvailabilityRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<DoctorAvailabilityRepository> logger = logger;

        //public async override Task<OperationResult> Save(DoctorAvailability entity)
        //{
        //    OperationResult result = new OperationResult();
        //    try
        //    {
        //        await base.Save(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = "Ocurrio un error guardando el DoctorAvailability";
        //        result.Success = false;
        //        this.logger.LogError(result.Message, ex.ToString());
        //    }
        //    return result;
        //}
    }
}

