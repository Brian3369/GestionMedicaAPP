using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Application.Response.Medical.MedicalRecords;

namespace GestionMedicaAPP.Application.Contracts.Medical
{
    public interface IMedicalRecordsService : IBaseService<MedicalRecordsResponse, MedicalRecordsSaveDto, MedicalRecordsUpdateDto>
    {
    }
}
