using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class MedicalRecordsAdmController : Controller
    {
        // GET: MedicalRecordsAdmController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MedicalRecordsAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalRecordsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecordsAdmController/Create
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

        // GET: MedicalRecordsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalRecordsAdmController/Edit/5
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

        // GET: MedicalRecordsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalRecordsAdmController/Delete/5
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
