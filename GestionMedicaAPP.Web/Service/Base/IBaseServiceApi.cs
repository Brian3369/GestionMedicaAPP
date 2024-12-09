using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base
{
    public interface IBaseServiceApi<GetAllModel, GetByIdModel, SaveDto>
    {
        Task<GetAllModel> GetAllAsync();
        Task<GetByIdModel> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(SaveDto saveDto);
        Task<BaseApiResponse> UpdateAsync(SaveDto saveDto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}
