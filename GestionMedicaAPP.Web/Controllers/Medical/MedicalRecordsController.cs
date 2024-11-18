using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordsService _MedicalRecordssService;

        public MedicalRecordsController(IMedicalRecordsService medicalRecordssService)
        {
            _MedicalRecordssService = medicalRecordssService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _MedicalRecordssService.GetAll();
            if (result.IsSuccess)
            {
                List<MedicalRecordsModel> medicalRecordssModel = (List<MedicalRecordsModel>)result.Model;
                return View(medicalRecordssModel);
            }
            return View();
        }

        // GET: MedicalRecordsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicalRecordsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecordsController/Create
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

        // GET: MedicalRecordsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicalRecordsController/Edit/5
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

        // GET: MedicalRecordsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicalRecordsController/Delete/5
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
