using GestionMedicaAPP.Application.Contracts.Insurance;
using GestionMedicaAPP.Persistance.Models.Insurance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class NetworkTypesController : Controller
    {
        private readonly INetworkTypeService _NetworkTypesService;

        public NetworkTypesController(INetworkTypeService networkTypesService)
        {
            _NetworkTypesService = networkTypesService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _NetworkTypesService.GetAll();
            if (result.IsSuccess)
            {
                List<NetworkTypeModel> networkTypesModel = (List<NetworkTypeModel>)result.Model;
                return View(networkTypesModel);
            }
            return View();
        }

        // GET: NetworkTypesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NetworkTypesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NetworkTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NetworkTypesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NetworkTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NetworkTypesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NetworkTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
