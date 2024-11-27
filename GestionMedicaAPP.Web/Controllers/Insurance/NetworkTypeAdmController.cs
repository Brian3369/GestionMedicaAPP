using GestionMedicaAPP.Web.Models.Insurance.InsuranceProviders;
using GestionMedicaAPP.Web.Models.Insurance.NetworkType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class NetworkTypeAdmController : Controller
    {
        // GET: NetworkTypeAdmController
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5222/api/InsuranceProviders/";
            NetworkTypeGetAllModel networkTypeGetAllModel = new NetworkTypeGetAllModel();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("GetNetworkType");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    networkTypeGetAllModel = JsonConvert.DeserializeObject<NetworkTypeGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(networkTypeGetAllModel.model);
        }

        // GET: NetworkTypeAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NetworkTypeAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NetworkTypeAdmController/Create
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

        // GET: NetworkTypeAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NetworkTypeAdmController/Edit/5
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

        // GET: NetworkTypeAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NetworkTypeAdmController/Delete/5
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
