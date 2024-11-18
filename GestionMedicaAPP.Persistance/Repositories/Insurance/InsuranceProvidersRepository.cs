using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Base;
using GestionMedicaAPP.Persistance.Context;
using GestionMedicaAPP.Persistance.Interfaces.Insurance;
using GestionMedicaAPP.Persistance.Models.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GestionMedicaAPP.Persistance.Repositories.Insurance
{
    public class InsuranceProvidersRepository(GestionMedicaContext context, ILogger<InsuranceProvidersRepository> logger) : BaseRepository<InsuranceProviders>(context), IInsuranceProvidersRepository
    {
        private readonly GestionMedicaContext _context = context;
        private readonly ILogger<InsuranceProvidersRepository> _logger = logger;

        public async override Task<OperationResult> Save(InsuranceProviders entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El proveedor de seguros no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                result.Success = false;
                result.Message = "El nombre del proveedor de seguros es requerido.";
                return result;
            }

            if (await base.Exists(p => p.Name == entity.Name))
            {
                result.Success = false;
                result.Message = "El proveedor de seguros ya existe.";
                return result;
            }

            try
            {
                result = await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error guardando el proveedor de seguros.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<OperationResult> Update(InsuranceProviders entity)
        {
            OperationResult result = new OperationResult();

            if (entity == null)
            {
                result.Success = false;
                result.Message = "El proveedor de seguros no puede ser nulo.";
                return result;
            }

            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                result.Success = false;
                result.Message = "El nombre del proveedor de seguros es requerido.";
                return result;
            }

            try
            {
                result = await base.Update(entity);
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error actualizando el proveedor de seguros.";
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
                result.Data = await (from provider in _context.InsuranceProvider
                                     where provider.StatusID == 1
                                     select new InsuranceProvidersModel()
                                     {
                                         InsuranceProviderID = provider.InsuranceProviderID,
                                         Name = provider.Name,
                                         StatusID = provider.StatusID,
                                         CreatedAt = provider.CreatedAt,
                                         UpdatedAt = provider.UpdatedAt
                                     }).AsNoTracking()
                                    .ToListAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo los proveedores de seguros.";
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
                var provider = await (from p in _context.InsuranceProvider
                                      where p.InsuranceProviderID == id
                                      select new InsuranceProvidersModel()
                                      {
                                          InsuranceProviderID = p.InsuranceProviderID,
                                          Name = p.Name,
                                          CreatedAt = p.CreatedAt,
                                          UpdatedAt = p.UpdatedAt
                                      }).AsNoTracking()
                                        .FirstOrDefaultAsync();

                if (provider == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el proveedor de seguros.";
                    return result;
                }

                result.Data = provider;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrió un error obteniendo el proveedor de seguros.";
                result.Success = false;
                _logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}