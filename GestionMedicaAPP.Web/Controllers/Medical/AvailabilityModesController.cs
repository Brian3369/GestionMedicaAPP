using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.AvailabilityModes;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class AvailabilityModesController : Controller
    {
        private readonly IAvailabilityModesService _availabilityModesService;

        public AvailabilityModesController(IAvailabilityModesService availabilityModesService)
        {
            _availabilityModesService = availabilityModesService;
        }

        // GET: AvailabilityModesController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _availabilityModesService.GetAll();
            if (result.IsSuccess)
            {
                List<AvailabilityModesModel> availabilityModeModels = (List<AvailabilityModesModel>)result.Model;
                return View(availabilityModeModels);
            }
            return View();
        }

        // GET: AvailabilityModesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _availabilityModesService.GetById(id);
            if (result.IsSuccess)
            {
                AvailabilityModesModel availabilityModeModel = (AvailabilityModesModel)result.Model;
                return View(availabilityModeModel);
            }
            return View();
        }

        // GET: AvailabilityModesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AvailabilityModesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityModesSaveDto availabilityModeSaveDto)
        {
            try
            {
                var result = await _availabilityModesService.SaveAsync(availabilityModeSaveDto);
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

        // GET: AvailabilityModesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _availabilityModesService.GetById(id);
            if (result.IsSuccess)
            {
                AvailabilityModesModel availabilityModeModel = (AvailabilityModesModel)result.Model;
                return View(availabilityModeModel);
            }
            return View();
        }

        // POST: AvailabilityModesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AvailabilityModesUpdateDto availabilityModeUpdateDto)
        {
            try
            {
                var result = await _availabilityModesService.UpdateAsync(availabilityModeUpdateDto);
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