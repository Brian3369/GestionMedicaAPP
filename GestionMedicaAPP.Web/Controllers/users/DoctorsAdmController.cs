using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class DoctorsAdmController : Controller
    {
        // GET: DoctorsAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DoctorsAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsAdmController/Create
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

        // GET: DoctorsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorsAdmController/Edit/5
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

        // GET: DoctorsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorsAdmController/Delete/5
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
