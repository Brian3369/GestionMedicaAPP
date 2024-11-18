using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Persistance.Models.Insurance;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class AvailabilityModesController : Controller
    {
        private readonly IAvailabilityModesService _AvailabilityModessService;

        public AvailabilityModesController(IAvailabilityModesService AvailabilityModessService)
        {
            _AvailabilityModessService = AvailabilityModessService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _AvailabilityModessService.GetAll();
            if (result.IsSuccess)
            {
                List<AvailabilityModesModel> AvailabilityModessModel = (List<AvailabilityModesModel>)result.Model;
                return View(AvailabilityModessModel);
            }
            return View();
        }

        // GET: AvailabilityModesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AvailabilityModesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailabilityModesController/Create
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

        // GET: AvailabilityModesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AvailabilityModesController/Edit/5
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

        // GET: AvailabilityModesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AvailabilityModesController/Delete/5
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
