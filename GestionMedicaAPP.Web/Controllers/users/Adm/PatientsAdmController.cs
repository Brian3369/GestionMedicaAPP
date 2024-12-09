using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Web.Service.ServiceApi.Users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users.Adm
{
    public class PatientsAdmController : Controller
    {
        private readonly PatientServiceApi _patientService;

        public PatientsAdmController(PatientServiceApi patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _patientService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching patients.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _patientService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching patient details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientsSaveDto patient)
        {
            var response = await _patientService.CreateAsync(patient);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating patient.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _patientService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching patient for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientsSaveDto patient)
        {
            var response = await _patientService.UpdateAsync(patient);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating patient.";
            return View(patient);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _patientService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting patient.";
            return RedirectToAction(nameof(Index));
        }
    }
}
