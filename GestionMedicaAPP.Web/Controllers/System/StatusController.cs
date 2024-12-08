using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Status;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class StatusController : Controller
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET: StatusController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _statusService.GetAll();
            if (result.IsSuccess)
            {
                List<StatusModel> statusModels = (List<StatusModel>)result.Model;
                return View(statusModels);
            }
            return View();
        }

        // GET: StatusController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _statusService.GetById(id);
            if (result.IsSuccess)
            {
                StatusModel statusModel = (StatusModel)result.Model;
                return View(statusModel);
            }
            return View();
        }

        // GET: StatusController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusSaveDto statusSaveDto)
        {
            try
            {
                var result = await _statusService.SaveAsync(statusSaveDto);
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

        // GET: StatusController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _statusService.GetById(id);
            if (result.IsSuccess)
            {
                StatusModel statusModel = (StatusModel)result.Model;
                return View(statusModel);
            }
            return View();
        }

        // POST: StatusController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StatusUpdateDto statusUpdateDto)
        {
            try
            {
                var result = await _statusService.UpdateAsync(statusUpdateDto);
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