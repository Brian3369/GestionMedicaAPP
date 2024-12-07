using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Service.Base.Insurance.InsuranceProviders;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class InsuranceProvidersAdmController : Controller
    {
        private readonly IInsuranceProvidersApiService _insuranceProvidersService;

        public InsuranceProvidersAdmController(IInsuranceProvidersApiService insuranceProvidersService)
        {
            _insuranceProvidersService = insuranceProvidersService;
        }

        public async Task<IActionResult> Index()
        {
            var providers = await _insuranceProvidersService.GetAllAsync();
            return View(providers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var provider = await _insuranceProvidersService.GetByIdAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceProviderSaveDto provider)
        {
            if (!ModelState.IsValid) return View(provider);

            var result = await _insuranceProvidersService.CreateAsync(provider);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var provider = await _insuranceProvidersService.GetByIdAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InsuranceProviderSaveDto provider)
        {
            if (!ModelState.IsValid) return View(provider);

            var result = await _insuranceProvidersService.UpdateAsync(id, provider);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var provider = await _insuranceProvidersService.GetByIdAsync(id);
            if (provider == null)
            {
                return NotFound();
            }
            return View(provider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _insuranceProvidersService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

