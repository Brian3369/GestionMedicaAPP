using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class NotificationsAdmController : Controller
    {
        private readonly INotificationsApiService _notificationsService;

        public NotificationsAdmController(INotificationsApiService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        public async Task<IActionResult> Index()
        {
            var notifications = await _notificationsService.GetAllAsync();
            return View(notifications);
        }

        public async Task<IActionResult> Details(int id)
        {
            var notification = await _notificationsService.GetByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotificationSaveDto notification)
        {
            if (!ModelState.IsValid) return View(notification);

            var result = await _notificationsService.CreateAsync(notification);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var notification = await _notificationsService.GetByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NotificationSaveDto notification)
        {
            if (!ModelState.IsValid) return View(notification);

            var result = await _notificationsService.UpdateAsync(id, notification);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var notification = await _notificationsService.GetByIdAsync(id);
            if (notification == null)
            {
                return NotFound();
            }
            return View(notification);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _notificationsService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
