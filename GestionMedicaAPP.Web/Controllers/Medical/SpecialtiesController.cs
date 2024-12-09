using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.Specialties;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtiesService _specialtiesService;

        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        // GET: SpecialtiesController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _specialtiesService.GetAll();
            if (result.IsSuccess)
            {
                List<SpecialtiesModel> specialtyModels = (List<SpecialtiesModel>)result.Model;
                return View(specialtyModels);
            }
            return View();
        }

        // GET: SpecialtiesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _specialtiesService.GetById(id);
            if (result.IsSuccess)
            {
                SpecialtiesModel specialtyModel = (SpecialtiesModel)result.Model;
                return View(specialtyModel);
            }
            return View();
        }

        // GET: SpecialtiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialtiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialtiesSaveDto specialtySaveDto)
        {
            try
            {
                var result = await _specialtiesService.SaveAsync(specialtySaveDto);
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

        // GET: SpecialtiesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _specialtiesService.GetById(id);
            if (result.IsSuccess)
            {
                SpecialtiesModel specialtyModel = (SpecialtiesModel)result.Model;
                return View(specialtyModel);
            }
            return View();
        }

        // POST: SpecialtiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SpecialtiesUpdateDto specialtyUpdateDto)
        {
            try
            {
                var result = await _specialtiesService.UpdateAsync(specialtyUpdateDto);
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