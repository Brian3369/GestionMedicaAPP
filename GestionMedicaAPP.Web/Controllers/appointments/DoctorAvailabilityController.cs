using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Persistance.Models.appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.appointments
{
    public class DoctorAvailabilityController : Controller
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _doctorAvailabilityService.GetAll();
            if (result.IsSuccess)
            {
                List<DoctorAvailabilityModel> doctorAvailabilityModels = (List<DoctorAvailabilityModel>)result.Model;
                return View(doctorAvailabilityModels);
            }
            return View();
        }

        // GET: AppointmentsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);
            if (result.IsSuccess)
            {
                DoctorAvailabilityModel doctorAvailabilityModel = (DoctorAvailabilityModel)result.Model;
                return View(doctorAvailabilityModel);
            }
            return View();
        }

        // GET: AppointmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            try
            {
                var result = await _doctorAvailabilityService.SaveAsync(doctorAvailabilitySaveDto);
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

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);
            if (result.IsSuccess)
            {
                DoctorAvailabilityModel doctorAvailabilityModel = (DoctorAvailabilityModel)result.Model;
                return View(doctorAvailabilityModel);
            }
            return View();
        }

        // POST: AppointmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            try
            {
                var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailabilityUpdateDto);
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
