using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class UsersAdmController : Controller
    {
        // GET: UsersAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UsersAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersAdmController/Create
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

        // GET: UsersAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersAdmController/Edit/5
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

        // GET: UsersAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersAdmController/Delete/5
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
