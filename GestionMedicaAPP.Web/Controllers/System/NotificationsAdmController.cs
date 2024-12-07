using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class NotificationsAdmController : Controller
    {
        // GET: NotificationsAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NotificationsAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NotificationsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotificationsAdmController/Create
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

        // GET: NotificationsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NotificationsAdmController/Edit/5
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

        // GET: NotificationsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NotificationsAdmController/Delete/5
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
