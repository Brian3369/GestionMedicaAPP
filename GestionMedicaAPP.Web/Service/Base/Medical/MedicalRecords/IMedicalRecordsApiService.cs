using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Base.Medical.MedicalRecords
{
    public interface IMedicalRecordsApiService
    {
        Task<IEnumerable<MedicalRecordsBaseDto>> GetAllAsync();
        Task<MedicalRecordsBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(MedicalRecordsSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, MedicalRecordsSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}
