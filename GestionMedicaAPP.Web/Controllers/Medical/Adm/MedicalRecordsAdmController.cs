using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Service.Base.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical.Adm
{
    public class MedicalRecordsAdmController : Controller
    {
        private readonly MedicalRecordServiceApi _medicalRecordService;

        public MedicalRecordsAdmController(MedicalRecordServiceApi medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _medicalRecordService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching medical records.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _medicalRecordService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordsSaveDto medicalRecord)
        {
            var response = await _medicalRecordService.CreateAsync(medicalRecord);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating medical record.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _medicalRecordService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching medical record for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicalRecordsSaveDto medicalRecord)
        {
            var response = await _medicalRecordService.UpdateAsync(id, medicalRecord);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating medical record.";
            return View(medicalRecord);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _medicalRecordService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting medical record.";
            return RedirectToAction(nameof(Index));
        }
    }
}
