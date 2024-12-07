using GestionMedicaAPP.Application.Contracts.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class DoctorsAdmController : Controller
    {
        private readonly IDoctorsApiService _doctorsService;

        public DoctorsAdmController(IDoctorsApiService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorsService.GetAllAsync();
            return View(doctors);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorsService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorSaveDto doctor)
        {
            if (!ModelState.IsValid) return View(doctor);

            var result = await _doctorsService.CreateAsync(doctor);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorsService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DoctorSaveDto doctor)
        {
            if (!ModelState.IsValid) return View(doctor);

            var result = await _doctorsService.UpdateAsync(id, doctor);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorsService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _doctorsService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
