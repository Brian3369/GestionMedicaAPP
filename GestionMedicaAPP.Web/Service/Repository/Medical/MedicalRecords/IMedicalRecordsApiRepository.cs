using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.Base;

namespace GestionMedicaAPP.Web.Service.Repository.Medical.MedicalRecords
{
    public interface IMedicalRecordsApiRepository
    {
        Task<IEnumerable<MedicalRecordsBaseDto>> GetAllAsync();
        Task<MedicalRecordsBaseDto> GetByIdAsync(int id);
        Task<BaseApiResponse> CreateAsync(MedicalRecordsSaveDto dto);
        Task<BaseApiResponse> UpdateAsync(int id, MedicalRecordsSaveDto dto);
        Task<BaseApiResponse> DeleteAsync(int id);
    }
}
