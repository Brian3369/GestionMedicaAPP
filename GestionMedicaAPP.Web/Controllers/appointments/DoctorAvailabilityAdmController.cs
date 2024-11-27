using GestionMedicaAPP.Application.Dtos.Appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Models.appointments.DoctorAvailability;
using GestionMedicaAPP.Web.Models.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GestionMedicaAPP.Web.Controllers.appointments
{
    public class DoctorAvailabilityAdmController : Controller
    {
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5184/DoctorAvailability/";
            DoctorAvailabilityGetAllModel doctorAvailabilityGetAllModel = new DoctorAvailabilityGetAllModel();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseTask = await client.GetAsync("GetDoctorAvailability");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    doctorAvailabilityGetAllModel = JsonConvert.DeserializeObject<DoctorAvailabilityGetAllModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }
            }
            return View(doctorAvailabilityGetAllModel.model);
        }

        // GET: DoctorAvailabilityAdmController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5184/DoctorAvailability/";

            DoctorAvailabilityGetByIdModel doctorAvailabilityGetByIdModel = new DoctorAvailabilityGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"GetDoctorAvailabilityById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    doctorAvailabilityGetByIdModel = JsonConvert.DeserializeObject<DoctorAvailabilityGetByIdModel>(response);

                }
            }
            return View(doctorAvailabilityGetByIdModel.model);
        }

        // GET: DoctorAvailabilityAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorAvailabilityAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailability)
        {
            BaseApiResponse baseApi = new BaseApiResponse();

            try
            {
                string url = "http://localhost:5184/DoctorAvailability/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);


                    var responseTask = await client.PostAsJsonAsync<DoctorAvailabilitySaveDto>("SaveDoctorAvailability", doctorAvailability);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();

                        baseApi = JsonConvert.DeserializeObject<BaseApiResponse>(response);


                        if (!baseApi.isSuccess)
                        {
                            ViewBag.Message = baseApi.message;
                            return View();

                        }
                        else
                        {

                            return RedirectToAction(nameof(Index));
                        }
                    }
                    else
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        baseApi = JsonConvert.DeserializeObject<BaseApiResponse>(response);

                        ViewBag.Message = baseApi.message;
                        return View();
                    }


                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DoctorAvailabilityAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string url = "http://localhost:5184/DoctorAvailability/";
            DoctorAvailabilityGetByIdModel doctorAvailabilityGetByIdModel = new DoctorAvailabilityGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"GetDoctorAvailabilityById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    doctorAvailabilityGetByIdModel = JsonConvert.DeserializeObject<DoctorAvailabilityGetByIdModel>(response);

                }
            }
            return View(doctorAvailabilityGetByIdModel.model);
        }

            // POST: DoctorAvailabilityAdmController/Edit/5
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

        // GET: DoctorAvailabilityAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoctorAvailabilityAdmController/Delete/5
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
