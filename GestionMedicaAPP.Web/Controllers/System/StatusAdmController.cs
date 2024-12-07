using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Status;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class StatusAdmController : Controller
    {
        private readonly IStatusApiService _statusService;

        public StatusAdmController(IStatusApiService statusService)
        {
            _statusService = statusService;
        }

        public async Task<IActionResult> Index()
        {
            var statuses = await _statusService.GetAllAsync();
            return View(statuses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto status)
        {
            if (!ModelState.IsValid) return View(status);

            var result = await _statusService.CreateAsync(status);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StatusSaveDto status)
        {
            if (!ModelState.IsValid) return View(status);

            var result = await _statusService.UpdateAsync(id, status);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var status = await _statusService.GetByIdAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _statusService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
