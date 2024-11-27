using GestionMedicaAPP.Web.Models.appointments.appoitments;
using GestionMedicaAPP.Web.Models.Insurance.InsuranceProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace GestionMedicaAPP.Web.Controllers.Insurance
{
    public class InsuranceProvidersAdmController : Controller
    {
        // GET: InsuranceProvidersAdmController
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5222/api/InsuranceProviders/";
            InsuranceProvidersGetAllModel insuranceProvidersGetAllModel = new InsuranceProvidersGetAllModel();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("GetInsuranceProvider");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    insuranceProvidersGetAllModel = JsonConvert.DeserializeObject<InsuranceProvidersGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(insuranceProvidersGetAllModel.model);
        }

        // GET: InsuranceProvidersAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceProvidersAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceProvidersAdmController/Create
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

        // GET: InsuranceProvidersAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceProvidersAdmController/Edit/5
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

        // GET: InsuranceProvidersAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceProvidersAdmController/Delete/5
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
