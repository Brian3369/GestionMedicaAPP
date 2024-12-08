using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Roles;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class RolesController : Controller
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        // GET: RolesController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _rolesService.GetAll();
            if (result.IsSuccess)
            {
                List<RolesModel> roleModels = (List<RolesModel>)result.Model;
                return View(roleModels);
            }
            return View();
        }

        // GET: RolesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _rolesService.GetById(id);
            if (result.IsSuccess)
            {
                RolesModel roleModel = (RolesModel)result.Model;
                return View(roleModel);
            }
            return View();
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolesSaveDto roleSaveDto)
        {
            try
            {
                var result = await _rolesService.SaveAsync(roleSaveDto);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _rolesService.GetById(id);
            if (result.IsSuccess)
            {
                RolesModel roleModel = (RolesModel)result.Model;
                return View(roleModel);
            }
            return View();
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RolesUpdateDto roleUpdateDto)
        {
            try
            {
                var result = await _rolesService.UpdateAsync(roleUpdateDto);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}