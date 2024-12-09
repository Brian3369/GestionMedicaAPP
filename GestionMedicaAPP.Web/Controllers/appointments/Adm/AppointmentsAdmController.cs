using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Web.Service.Base.Appointmets;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.appointments.Adm
{
    public class AppointmentsAdmController : Controller
    {
        private readonly AppointmentServiceApi _appointmentsService;

        public AppointmentsAdmController(AppointmentServiceApi appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentsService.GetAllAsync();
            return View(appointments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsSaveDto appointment)
        {
            if (!ModelState.IsValid) return View(appointment);

            var result = await _appointmentsService.CreateAsync(appointment);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsSaveDto appointment)
        {
            if (!ModelState.IsValid) return View(appointment);

            var result = await _appointmentsService.UpdateAsync(appointment);

            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentsService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _appointmentsService.DeleteAsync(id);
            if (!result.isSuccess)
            {
                ViewBag.Message = result.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
