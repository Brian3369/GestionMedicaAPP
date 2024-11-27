using GestionMedicaAPP.Web.Models.appointments.appoitments;
using GestionMedicaAPP.Web.Models.appointments.DoctorAvailability;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Controllers.appointments
{
    public class AppointmentsAdmController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5184/Appointments/";
            AppointmentsGetAllModel appointmentsGetAllModel = new AppointmentsGetAllModel();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("GetAppointments");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    appointmentsGetAllModel = JsonConvert.DeserializeObject<AppointmentsGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(appointmentsGetAllModel.model);
        }

        // GET: AppointmentsAdmController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5184/Appointments/";

            AppointmentsGetAllModel appointmentsGetAllModel = new AppointmentsGetAllModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"GetAppointmentsById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    appointmentsGetAllModel = JsonConvert.DeserializeObject<AppointmentsGetAllModel>(response);

                }
            }
            return View(appointmentsGetAllModel.model);
        }

        // GET: AppointmentsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsAdmController/Create
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

        // GET: AppointmentsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentsAdmController/Edit/5
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

        // GET: AppointmentsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentsAdmController/Delete/5
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
