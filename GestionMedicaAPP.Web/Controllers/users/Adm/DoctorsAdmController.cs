using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.Doctors;
using GestionMedicaAPP.Application.Services.users;
using GestionMedicaAPP.Web.Service.ServiceApi.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class DoctorsAdmController : Controller
    {
        private readonly DoctorServiceApi _doctorService;

        public DoctorsAdmController(DoctorServiceApi doctorService)
        {
            _doctorService = doctorService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _doctorService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching doctors.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _doctorService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching doctor details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorsSaveDto doctor)
        {
            var response = await _doctorService.CreateAsync(doctor);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating doctor.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _doctorService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching doctor for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorsUpdateDto doctor)
        {
            var response = await _doctorService.UpdateAsync(doctor);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating doctor.";
            return View(doctor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _doctorService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting doctor.";
            return RedirectToAction(nameof(Index));
        }
    }
}
