using GestionMedicaAPP.Domain.Repositories;
using GestionMedicaAPP.Domain.Result;
using GestionMedicaAPP.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestionMedicaAPP.Persistance.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly GestionMedicaContext _gestionMedicaContext;
        private DbSet<TEntity> entities;
        public BaseRepository(GestionMedicaContext gestionMedicaContext)
        {
            _gestionMedicaContext = gestionMedicaContext;
            this.entities = _gestionMedicaContext.Set<TEntity>();
        }
        public virtual async Task<bool> Exists(Expression<Func<TEntity, bool>> filter)
        {
            return await this.entities.AnyAsync(filter);
        }

        public virtual async Task<OperationResult> GetAll()
        {
            OperationResult result = new OperationResult();

            try
            {
                var datos = await this.entities.ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;
        }

        public virtual async Task<OperationResult> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            OperationResult result = new OperationResult();

            try
            {
                var datos = await this.entities.Where(filter).ToListAsync();
                result.Data = datos;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo los datos.";
            }

            return result;

        }

        public virtual async Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();
            try
            {
                var entity = await this.entities.FindAsync(Id);
                result.Data = entity;
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} obteniendo la entidad.";
            }
            return result;
        }

        public async virtual Task<OperationResult> Remove(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Remove(entity);
                await _gestionMedicaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} removiendo la entidad.";

            }

            return result;
        }

        public async virtual Task<OperationResult> RemoveById(int id)
        {
            OperationResult result = new OperationResult();

            try
            {
                var entity = await this.entities.FindAsync(id);
                entities.Remove(entity);
                await _gestionMedicaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} removiendo la entidad por id.";

            }

            return result;
        }

        public virtual async Task<OperationResult> Save(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Add(entity);
                await _gestionMedicaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} guardando la entidad.";

            }

            return result;
        }

        public virtual async Task<OperationResult> Update(TEntity entity)
        {
            OperationResult result = new OperationResult();

            try
            {
                entities.Update(entity);
                await _gestionMedicaContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Ocurrió un error {ex.Message} actualizando la entidad.";

            }

            return result;
        }
    }
}
