using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Service.ServiceApi.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance.Adm
{
    public class NetworkTypeAdmController : Controller
    {
        private readonly NetworkTypeServiceApi _networkTypeService;

        public NetworkTypeAdmController(NetworkTypeServiceApi networkTypeService)
        {
            _networkTypeService = networkTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _networkTypeService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching network types.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _networkTypeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(NetworkTypeSaveDto networkType)
        {
            var response = await _networkTypeService.CreateAsync(networkType);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating network type.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _networkTypeService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching network type for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NetworkTypeSaveDto networkType)
        {
            var response = await _networkTypeService.UpdateAsync(networkType);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating network type.";
            return View(networkType);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _networkTypeService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting network type.";
            return RedirectToAction(nameof(Index));
        }
    }
}
