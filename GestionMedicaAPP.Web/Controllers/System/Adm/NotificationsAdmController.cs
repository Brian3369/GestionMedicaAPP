using GestionMedicaAPP.Application.Dtos.System.Notifications;
using GestionMedicaAPP.Web.Service.ServiceApi.System;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class NotificationsAdmController : Controller
    {
        private readonly NotificationServiceApi _notificationService;

        public NotificationsAdmController(NotificationServiceApi notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _notificationService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching notifications.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _notificationService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching notification details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationsSaveDto notification)
        {
            var response = await _notificationService.CreateAsync(notification);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating notification.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _notificationService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching notification for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NotificationsSaveDto notification)
        {
            var response = await _notificationService.UpdateAsync(notification);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating notification.";
            return View(notification);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _notificationService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting notification.";
            return RedirectToAction(nameof(Index));
        }
    }
}
