using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class SpecialtiesAdmController : Controller
    {
        private readonly ISpecialtiesApiService _specialtiesService;

        public SpecialtiesAdmController(ISpecialtiesApiService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        public async Task<IActionResult> Index()
        {
            var specialties = await _specialtiesService.GetAllAsync();
            return View(specialties);
        }

        public async Task<IActionResult> Details(int id)
        {
            var specialty = await _specialtiesService.GetByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialtySaveDto specialty)
        {
            if (!ModelState.IsValid) return View(specialty);

            var result = await _specialtiesService.CreateAsync(specialty);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var specialty = await _specialtiesService.GetByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialtySaveDto specialty)
        {
            if (!ModelState.IsValid) return View(specialty);

            var result = await _specialtiesService.UpdateAsync(id, specialty);

            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var specialty = await _specialtiesService.GetByIdAsync(id);
            if (specialty == null)
            {
                return NotFound();
            }
            return View(specialty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _specialtiesService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
