using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class NotificationsController : Controller
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        // GET: NotificationsController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _notificationsService.GetAll();
            if (result.IsSuccess)
            {
                List<NotificationsModel> notificationModels = (List<NotificationsModel>)result.Model;
                return View(notificationModels);
            }
            return View();
        }

        // GET: NotificationsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _notificationsService.GetById(id);
            if (result.IsSuccess)
            {
                NotificationsModel notificationModel = (NotificationsModel)result.Model;
                return View(notificationModel);
            }
            return View();
        }

        // GET: NotificationsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationsSaveDto notificationSaveDto)
        {
            try
            {
                var result = await _notificationsService.SaveAsync(notificationSaveDto);
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

        // GET: NotificationsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _notificationsService.GetById(id);
            if (result.IsSuccess)
            {
                NotificationsModel notificationModel = (NotificationsModel)result.Model;
                return View(notificationModel);
            }
            return View();
        }

        // POST: NotificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationsUpdateDto notificationUpdateDto)
        {
            try
            {
                var result = await _notificationsService.UpdateAsync(notificationUpdateDto);
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