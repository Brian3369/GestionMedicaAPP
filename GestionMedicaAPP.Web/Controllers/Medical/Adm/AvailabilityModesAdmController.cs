using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Web.Service.ServiceApi.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical.Adm
{
    public class AvailabilityModesAdmController : Controller
    {
        private readonly AvailabilityModeServiceApi _availabilityModeService;

        public AvailabilityModesAdmController(AvailabilityModeServiceApi availabilityModeService)
        {
            _availabilityModeService = availabilityModeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _availabilityModeService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching availability modes.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _availabilityModeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(AvailabilityModesSaveDto availabilityMode)
        {
            var response = await _availabilityModeService.CreateAsync(availabilityMode);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating availability mode.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _availabilityModeService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching availability mode for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityModesSaveDto availabilityMode)
        {
            var response = await _availabilityModeService.UpdateAsync(availabilityMode);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating availability mode.";
            return View(availabilityMode);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _availabilityModeService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting availability mode.";
            return RedirectToAction(nameof(Index));
        }
    }
}
