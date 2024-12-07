using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Service.Base.Appointmets.DoctorAvailability;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class DoctorAvailabilityAdmController : Controller
    {
        private readonly IDoctorAvailabilityApiService _doctorAvailabilityService;

        public DoctorAvailabilityAdmController(IDoctorAvailabilityApiService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        public async Task<IActionResult> Index()
        {
            var doctorAvailabilities = await _doctorAvailabilityService.GetAllAsync();
            return View(doctorAvailabilities);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctorAvailability = await _doctorAvailabilityService.GetByIdAsync(id);
            if (doctorAvailability == null)
            {
                return NotFound();
            }
            return View(doctorAvailability);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailability)
        {
            if (!ModelState.IsValid) return View(doctorAvailability);

            var result = await _doctorAvailabilityService.CreateAsync(doctorAvailability);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctorAvailability = await _doctorAvailabilityService.GetByIdAsync(id);
            if (doctorAvailability == null)
            {
                return NotFound();
            }
            return View(doctorAvailability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorAvailabilitySaveDto doctorAvailability)
        {
            if (!ModelState.IsValid) return View(doctorAvailability);

            var result = await _doctorAvailabilityService.UpdateAsync(id, doctorAvailability);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctorAvailability = await _doctorAvailabilityService.GetByIdAsync(id);
            if (doctorAvailability == null)
            {
                return NotFound();
            }
            return View(doctorAvailability);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _doctorAvailabilityService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
