using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Web.Service.ServiceApi.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System.Adm
{
    public class RolesAdmController : Controller
    {
        private readonly RoleServiceApi _roleService;

        public RolesAdmController(RoleServiceApi roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _roleService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching roles.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _roleService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching role details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesSaveDto role)
        {
            var response = await _roleService.CreateAsync(role);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating role.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _roleService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching role for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesUpdateDto role)
        {
            var response = await _roleService.UpdateAsync(role);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating role.";
            return View(role);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _roleService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting role.";
            return RedirectToAction(nameof(Index));
        }
    }
}
