using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Application.Dtos.Insurance.NetworkType;
using GestionMedicaAPP.Persistance.Models.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class NetworkTypeController : Controller
    {
        private readonly INetworkTypeService _networkTypeService;

        public NetworkTypeController(INetworkTypeService networkTypeService)
        {
            _networkTypeService = networkTypeService;
        }

        // GET: NetworkTypeController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _networkTypeService.GetAll();
            if (result.IsSuccess)
            {
                List<NetworkTypeModel> networkTypeModels = (List<NetworkTypeModel>)result.Model;
                return View(networkTypeModels);
            }
            return View();
        }

        // GET: NetworkTypeController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _networkTypeService.GetById(id);
            if (result.IsSuccess)
            {
                NetworkTypeModel networkTypeModel = (NetworkTypeModel)result.Model;
                return View(networkTypeModel);
            }
            return View();
        }

        // GET: NetworkTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NetworkTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NetworkTypeSaveDto networkTypeSaveDto)
        {
            try
            {
                var result = await _networkTypeService.SaveAsync(networkTypeSaveDto);
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

        // GET: NetworkTypeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _networkTypeService.GetById(id);
            if (result.IsSuccess)
            {
                NetworkTypeModel networkTypeModel = (NetworkTypeModel)result.Model;
                return View(networkTypeModel);
            }
            return View();
        }

        // POST: NetworkTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NetworkTypeUpdateDto networkTypeUpdateDto)
        {
            try
            {
                var result = await _networkTypeService.UpdateAsync(networkTypeUpdateDto);
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