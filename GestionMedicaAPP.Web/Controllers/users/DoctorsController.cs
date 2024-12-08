using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorsService _doctorsService;

        public DoctorsController(IDoctorsService doctorsService)
        {
            _doctorsService = doctorsService;
        }

        // GET: DoctorsController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _doctorsService.GetAll();
            if (result.IsSuccess)
            {
                List<DoctorsModel> doctorModels = (List<DoctorsModel>)result.Model;
                return View(doctorModels);
            }
            return View();
        }

        // GET: DoctorsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _doctorsService.GetById(id);
            if (result.IsSuccess)
            {
                DoctorsModel doctorModel = (DoctorsModel)result.Model;
                return View(doctorModel);
            }
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
        public async Task<IActionResult> Create(DoctorsSaveDto doctorSaveDto)
        {
            try
            {
                var result = await _doctorsService.SaveAsync(doctorSaveDto);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _doctorsService.GetById(id);
            if (result.IsSuccess)
            {
                DoctorsModel doctorModel = (DoctorsModel)result.Model;
                return View(doctorModel);
            }
            return View();
        }

        // POST: DoctorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorsUpdateDto doctorUpdateDto)
        {
            try
            {
                var result = await _doctorsService.UpdateAsync(doctorUpdateDto);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}