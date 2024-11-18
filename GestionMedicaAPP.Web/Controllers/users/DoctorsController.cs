using GestionMedicaAPP.Application.Contracts.System;
using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Persistance.Models.System;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _DoctorssService;

        public DoctorsController(IDoctorsService DoctorssService)
        {
            _DoctorssService = DoctorssService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _DoctorssService.GetAll();
            if (result.IsSuccess)
            {
                List<DoctorsModel> DoctorssModel = (List<DoctorsModel>)result.Model;
                return View(DoctorssModel);
            }
            return View();
        }

        // GET: DoctorsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorsController/Create
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

        // GET: DoctorsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoctorsController/Edit/5
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

        // GET: DoctorsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorsController/Delete/5
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
