using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Web.Service.Base.Medical;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestionMedicaAPP.Web.Controllers.Medical.Adm
{
    public class SpecialtiesAdmController : Controller
    {
        private readonly SpecialtiesServiceApi _specialtyService;

        public SpecialtiesAdmController(SpecialtiesServiceApi specialtyService)
        {
            _specialtyService = specialtyService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _specialtyService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching specialties.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _specialtyService.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(SpecialtiesSaveDto specialty)
        {
            var response = await _specialtyService.CreateAsync(specialty);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating specialty.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _specialtyService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching specialty for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialtiesSaveDto specialty)
        {
            var response = await _specialtyService.UpdateAsync(id, specialty);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating specialty.";
            return View(specialty);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _specialtyService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting specialty.";
            return RedirectToAction(nameof(Index));
        }
    }
}
