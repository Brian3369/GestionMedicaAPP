using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Service.Base.Medical.AvailabilityModes;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class AvailabilityModesAdmController : Controller
    {
        private readonly IAvailabilityModesApiService _availabilityModesService;

        public AvailabilityModesAdmController(IAvailabilityModesApiService availabilityModesService)
        {
            _availabilityModesService = availabilityModesService;
        }

        public async Task<IActionResult> Index()
        {
            var availabilityModes = await _availabilityModesService.GetAllAsync();
            return View(availabilityModes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var availabilityMode = await _availabilityModesService.GetByIdAsync(id);
            if (availabilityMode == null)
            {
                return NotFound();
            }
            return View(availabilityMode);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityModesSaveDto availabilityMode)
        {
            if (!ModelState.IsValid) return View(availabilityMode);

            var result = await _availabilityModesService.CreateAsync(availabilityMode);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var availabilityMode = await _availabilityModesService.GetByIdAsync(id);
            if (availabilityMode == null)
            {
                return NotFound();
            }
            return View(availabilityMode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AvailabilityModesSaveDto availabilityMode)
        {
            if (!ModelState.IsValid) return View(availabilityMode);

            var result = await _availabilityModesService.UpdateAsync(id, availabilityMode);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var availabilityMode = await _availabilityModesService.GetByIdAsync(id);
            if (availabilityMode == null)
            {
                return NotFound();
            }
            return View(availabilityMode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _availabilityModesService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
