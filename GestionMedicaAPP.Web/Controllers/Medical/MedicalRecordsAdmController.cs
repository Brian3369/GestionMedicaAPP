using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Web.Service.Base.Medical.MedicalRecords;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class MedicalRecordsAdmController : Controller
    {
        private readonly IMedicalRecordsApiService _medicalRecordsService;

        public MedicalRecordsAdmController(IMedicalRecordsApiService medicalRecordsService)
        {
            _medicalRecordsService = medicalRecordsService;
        }

        public async Task<IActionResult> Index()
        {
            var medicalRecords = await _medicalRecordsService.GetAllAsync();
            return View(medicalRecords);
        }

        public async Task<IActionResult> Details(int id)
        {
            var medicalRecord = await _medicalRecordsService.GetByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordsSaveDto medicalRecord)
        {
            if (!ModelState.IsValid) return View(medicalRecord);

            var result = await _medicalRecordsService.CreateAsync(medicalRecord);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medicalRecord = await _medicalRecordsService.GetByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MedicalRecordsSaveDto medicalRecord)
        {
            if (!ModelState.IsValid) return View(medicalRecord);

            var result = await _medicalRecordsService.UpdateAsync(id, medicalRecord);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var medicalRecord = await _medicalRecordsService.GetByIdAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            return View(medicalRecord);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _medicalRecordsService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
