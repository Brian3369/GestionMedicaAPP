using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Patients;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class PatientsController : Controller
    {
        private readonly IPatientsService _patientsService;

        public PatientsController(IPatientsService patientsService)
        {
            _patientsService = patientsService;
        }

        // GET: PatientsController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _patientsService.GetAll();
            if (result.IsSuccess)
            {
                List<PatientsModel> patientModels = (List<PatientsModel>)result.Model;
                return View(patientModels);
            }
            return View();
        }

        // GET: PatientsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _patientsService.GetById(id);
            if (result.IsSuccess)
            {
                PatientsModel patientModel = (PatientsModel)result.Model;
                return View(patientModel);
            }
            return View();
        }

        // GET: PatientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientsSaveDto patientSaveDto)
        {
            try
            {
                var result = await _patientsService.SaveAsync(patientSaveDto);
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

        // GET: PatientsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _patientsService.GetById(id);
            if (result.IsSuccess)
            {
                PatientsModel patientModel = (PatientsModel)result.Model;
                return View(patientModel);
            }
            return View();
        }

        // POST: PatientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientsUpdateDto patientUpdateDto)
        {
            try
            {
                var result = await _patientsService.UpdateAsync(patientUpdateDto);
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