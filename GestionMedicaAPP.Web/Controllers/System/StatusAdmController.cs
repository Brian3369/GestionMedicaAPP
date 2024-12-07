using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.System
{
    public class StatusAdmController : Controller
    {
        // GET: StatusAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: StatusAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StatusAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusAdmController/Create
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

        // GET: StatusAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatusAdmController/Edit/5
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

        // GET: StatusAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatusAdmController/Delete/5
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
