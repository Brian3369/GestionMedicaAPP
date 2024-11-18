using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Persistance.Models.Medical;
using GestionMedicaAPP.Persistance.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class NotificationsController : Controller
    {
        private readonly INotificationsService _NotificationssService;

        public NotificationsController(INotificationsService NotificationssService)
        {
            _NotificationssService = NotificationssService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _NotificationssService.GetAll();
            if (result.IsSuccess)
            {
                List<NotificationsModel> NotificationssModel = (List<NotificationsModel>)result.Model;
                return View(NotificationssModel);
            }
            return View();
        }

        // GET: NotificationsController/Details/5
        public ActionResult Details(int id)
        {
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificationsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NotificationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificationsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
