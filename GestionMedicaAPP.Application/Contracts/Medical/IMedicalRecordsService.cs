using GestionMedicaAPP.Application.Base;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Application.Response.Medical.AvailabilityModes;
using GestionMedicaAPP.Persistance.Repositories.Medical;

namespace GestionMedicaAPP.Application.Contracts.Medical
{
    public interface IMedicalRecordsService : IBaseService<MedicalRecordsRepository, MedicalRecordsSaveDto, MedicalRecordsUpdateDto>
    {
    }
}
