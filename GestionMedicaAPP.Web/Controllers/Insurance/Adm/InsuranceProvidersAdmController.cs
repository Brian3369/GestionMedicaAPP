using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Web.Service.ServiceApi.Insurance;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance.Adm
{
    public class InsuranceProvidersAdmController : Controller
    {
        private readonly InsuranceProviderServiceApi _insuranceProviderService;

        public InsuranceProvidersAdmController(InsuranceProviderServiceApi insuranceProviderService)
        {
            _insuranceProviderService = insuranceProviderService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _insuranceProviderService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching insurance providers.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _insuranceProviderService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching details.";
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceProviderSaveDto insuranceProvider)
        {
            var response = await _insuranceProviderService.CreateAsync(insuranceProvider);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating insurance provider.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _insuranceProviderService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching insurance provider for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InsuranceProviderSaveDto insuranceProvider)
        {
            var response = await _insuranceProviderService.UpdateAsync(insuranceProvider);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating insurance provider.";
            return View(insuranceProvider);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _insuranceProviderService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting insurance provider.";
            return RedirectToAction(nameof(Index));
        }
    }
}

