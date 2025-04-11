using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Service.ServiceApi.Appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.appointments.Adm
{
    public class DoctorAvailabilityAdmController : Controller
    {
        private readonly DoctorAvailabilityServiceApi _doctorAvailabilityService;

        public DoctorAvailabilityAdmController(DoctorAvailabilityServiceApi doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _doctorAvailabilityService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching data.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _doctorAvailabilityService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching details.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailability)
        {
            var response = await _doctorAvailabilityService.CreateAsync(doctorAvailability);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating record.";
            return View(response);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _doctorAvailabilityService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching availability.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorAvailabilitySaveDto doctorAvailability)
        {
            var response = await _doctorAvailabilityService.UpdateAsync(doctorAvailability);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating availability.";
            return View(doctorAvailability);
        }

    }
}

