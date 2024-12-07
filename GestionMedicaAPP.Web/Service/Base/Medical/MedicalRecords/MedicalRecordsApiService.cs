using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Models.Base;
using GestionMedicaAPP.Web.Service.Repository.Medical.MedicalRecords;

namespace GestionMedicaAPP.Web.Service.Base.Medical.MedicalRecords
{
    public class MedicalRecordsService : IMedicalRecordsApiService
    {
        private readonly IMedicalRecordsApiRepository _repository;

        public MedicalRecordsService(IMedicalRecordsApiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<MedicalRecordsBaseDto>> GetAllAsync() => _repository.GetAllAsync();

        public Task<MedicalRecordsBaseDto> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<BaseApiResponse> CreateAsync(MedicalRecordsSaveDto dto) => _repository.CreateAsync(dto);

        public Task<BaseApiResponse> UpdateAsync(int id, MedicalRecordsSaveDto dto) => _repository.UpdateAsync(id, dto);

        public Task<BaseApiResponse> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
