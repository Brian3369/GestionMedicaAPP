using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class InsuranceProvidersController : Controller
    {
        private readonly IInsuranceProvidersService _insuranceProvidersService;

        public InsuranceProvidersController(IInsuranceProvidersService insuranceProvidersService)
        {
            _insuranceProvidersService = insuranceProvidersService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _insuranceProvidersService.GetAll();
            if (result.IsSuccess)
            {
                List<InsuranceProvidersModel> insuranceProvidersModel = (List<InsuranceProvidersModel>)result.Model;
                return View(insuranceProvidersModel);
            }
            return View();
        }

        // GET: InsuranceProvidersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceProvidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceProvidersController/Create
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

        // GET: InsuranceProvidersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceProvidersController/Edit/5
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

        // GET: InsuranceProvidersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceProvidersController/Delete/5
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
