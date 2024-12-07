using GestionMedicaAPP.Application.Contracts.Appointments;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Persistance.Models.appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.appointments
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _appointmentsService.GetAll();
            if (result.IsSuccess)
            {
                List<AppointmentsModel> appointmentsModel = (List<AppointmentsModel>)result.Model;
                return View(appointmentsModel);
            }
            return View();
        }

        // GET: AppointmentsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _appointmentsService.GetById(id);
            if (result.IsSuccess)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Model;
                return View(appointmentsModel);
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
        public async Task<IActionResult> Create(AppointmentsSaveDto appointmentsSaveDto)
        {
            try
            {
                appointmentsSaveDto.UpdatedAt = DateTime.Now;
                var result = await _appointmentsService.SaveAsync(appointmentsSaveDto);
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
            var result = await _appointmentsService.GetById(id);
            if (result.IsSuccess)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Model;
                return View(appointmentsModel);
            }
            return View();
        }

        // POST: AppointmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsUpdateDto appointmentsUpdateDto)
        {
            try
            {
                appointmentsUpdateDto.UpdatedAt = DateTime.Now;
                var result = await _appointmentsService.UpdateAsync(appointmentsUpdateDto);
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

        // GET: AppointmentsController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appointmentsService.RemoveById(id);
            if (result.IsSuccess)
            {
                return View();
            }
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
