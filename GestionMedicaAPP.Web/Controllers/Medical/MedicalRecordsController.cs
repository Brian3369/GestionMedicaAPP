using GestionMedicaAPP.Application.Contracts.Medical;
using GestionMedicaAPP.Application.Dtos.Medical.MedicalRecords;
using GestionMedicaAPP.Persistance.Models.Medical;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Medical
{
    public class MedicalRecordsController : Controller
    {
        private readonly IMedicalRecordsService _medicalRecordsService;

        public MedicalRecordsController(IMedicalRecordsService medicalRecordsService)
        {
            _medicalRecordsService = medicalRecordsService;
        }

        // GET: MedicalRecordsController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _medicalRecordsService.GetAll();
            if (result.IsSuccess)
            {
                List<MedicalRecordsModel> medicalRecordModels = (List<MedicalRecordsModel>)result.Model;
                return View(medicalRecordModels);
            }
            return View();
        }

        // GET: MedicalRecordsController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _medicalRecordsService.GetById(id);
            if (result.IsSuccess)
            {
                MedicalRecordsModel medicalRecordModel = (MedicalRecordsModel)result.Model;
                return View(medicalRecordModel);
            }
            return View();
        }

        // GET: MedicalRecordsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalRecordsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecordsSaveDto medicalRecordSaveDto)
        {
            try
            {
                var result = await _medicalRecordsService.SaveAsync(medicalRecordSaveDto);
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

        // GET: MedicalRecordsController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _medicalRecordsService.GetById(id);
            if (result.IsSuccess)
            {
                MedicalRecordsModel medicalRecordModel = (MedicalRecordsModel)result.Model;
                return View(medicalRecordModel);
            }
            return View();
        }

        // POST: MedicalRecordsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecordsUpdateDto medicalRecordUpdateDto)
        {
            try
            {
                var result = await _medicalRecordsService.UpdateAsync(medicalRecordUpdateDto);
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