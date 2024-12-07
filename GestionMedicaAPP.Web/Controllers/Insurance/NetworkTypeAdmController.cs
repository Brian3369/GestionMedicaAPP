using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Web.Service.Base.Insurance.NetworkType;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class NetworkTypeAdmController : Controller
    {
        private readonly INetworkTypeApiService _networkTypeService;

        public NetworkTypeAdmController(INetworkTypeApiService networkTypeService)
        {
            _networkTypeService = networkTypeService;
        }

        public async Task<IActionResult> Index()
        {
            var networkTypes = await _networkTypeService.GetAllAsync();
            return View(networkTypes);
        }

        public async Task<IActionResult> Details(int id)
        {
            var networkType = await _networkTypeService.GetByIdAsync(id);
            if (networkType == null)
            {
                return NotFound();
            }
            return View(networkType);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NetworkTypeSaveDto networkType)
        {
            if (!ModelState.IsValid) return View(networkType);

            var result = await _networkTypeService.CreateAsync(networkType);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var networkType = await _networkTypeService.GetByIdAsync(id);
            if (networkType == null)
            {
                return NotFound();
            }
            return View(networkType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NetworkTypeSaveDto networkType)
        {
            if (!ModelState.IsValid) return View(networkType);

            var result = await _networkTypeService.UpdateAsync(id, networkType);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var networkType = await _networkTypeService.GetByIdAsync(id);
            if (networkType == null)
            {
                return NotFound();
            }
            return View(networkType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _networkTypeService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
