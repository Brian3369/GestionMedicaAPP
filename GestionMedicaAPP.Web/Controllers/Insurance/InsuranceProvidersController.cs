using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.InsuranceProvider;
using GestionMedicaAPP.Domain.Entities.Insurance;
using GestionMedicaAPP.Persistance.Models.appointmets;
using GestionMedicaAPP.Persistance.Models.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class InsuranceProvidersController : Controller
    {
        private readonly IInsuranceProvidersService _insuranceProvidersService;

        public InsuranceProvidersController(IInsuranceProvidersService insuranceProvidersService)
        {
            _insuranceProvidersService = insuranceProvidersService;
        }

        // GET: InsuranceProvidersController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _insuranceProvidersService.GetAll();
            if (result.IsSuccess)
            {
                List<InsuranceProvidersModel> insuranceProviderModels = (List<InsuranceProvidersModel>)result.Model;
                return View(insuranceProviderModels);
            }
            return View();
        }

        // GET: InsuranceProvidersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _insuranceProvidersService.GetById(id);
            if (result.IsSuccess)
            {
                InsuranceProvidersModel insuranceProviderModel = (InsuranceProvidersModel)result.Model;
                return View(insuranceProviderModel);
            }
            return View();
        }

        // GET: InsuranceProvidersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceProvidersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuranceProviderSaveDto insuranceProviderSaveDto)
        {
            try
            {
                var result = await _insuranceProvidersService.SaveAsync(insuranceProviderSaveDto);
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

        // GET: InsuranceProvidersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _insuranceProvidersService.GetById(id);
            if (result.IsSuccess)
            {
                InsuranceProvidersModel insuranceProviderModel = (InsuranceProvidersModel)result.Model;
                return View(insuranceProviderModel);
            }
            return View();
        }

        // POST: InsuranceProvidersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InsuranceProviderUpdateDto insuranceProviderUpdateDto)
        {
            try
            {
                var result = await _insuranceProvidersService.UpdateAsync(insuranceProviderUpdateDto);
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