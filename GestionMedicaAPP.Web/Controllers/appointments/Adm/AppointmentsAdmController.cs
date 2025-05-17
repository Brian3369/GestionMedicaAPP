using Azure;
using GestionMedicaAPP.Application.Dtos.Appointments.Appointments;
using GestionMedicaAPP.Domain.Entities.appointmets;
using GestionMedicaAPP.Web.Service.ServiceApi.Appointmets;
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
            var model = await _appointmentsService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching data.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _appointmentsService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching details.";
            return View();
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
            var model = await _appointmentsService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching availability.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsUpdateDto appointment)
        {
            var response = await _appointmentsService.UpdateAsync(appointment);

            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = response?.message ?? "Error updating availability.";
            return View(appointment);        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _appointmentsService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }
            ViewBag.Message = "Error removing appointment.";
            return View();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _appointmentsService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Message = response?.message ?? "Error deleting appointment.";
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
