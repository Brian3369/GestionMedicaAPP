using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Web.Service.ServiceApi.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class StatusAdmController : Controller
    {
        private readonly StatusServiceApi _statusService;

        public StatusAdmController(StatusServiceApi statusService)
        {
            _statusService = statusService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _statusService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching statuses.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _statusService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching status details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto status)
        {
            var response = await _statusService.CreateAsync(status);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating status.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _statusService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching status for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusSaveDto status)
        {
            var response = await _statusService.UpdateAsync(status);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating status.";
            return View(status);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _statusService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting status.";
            return RedirectToAction(nameof(Index));
        }
    }
}
