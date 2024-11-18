using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtiesService _SpecialtiessService;

        public SpecialtiesController(ISpecialtiesService SpecialtiessService)
        {
            _SpecialtiessService = SpecialtiessService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _SpecialtiessService.GetAll();
            if (result.IsSuccess)
            {
                List<SpecialtiesModel> SpecialtiessModel = (List<SpecialtiesModel>)result.Model;
                return View(SpecialtiessModel);
            }
            return View();
        }

        // GET: SpecialtiesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SpecialtiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialtiesController/Create
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

        // GET: SpecialtiesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SpecialtiesController/Edit/5
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

        // GET: SpecialtiesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SpecialtiesController/Delete/5
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
