using GestionMedicaAPP.Application.Dtos.Users.users;
using GestionMedicaAPP.Web.Service.ServiceApi.Users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers
{
    public class UsersAdmController : Controller
    {
        private readonly UserServiceApi _userService;

        public UsersAdmController(UserServiceApi userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _userService.GetAllAsync();
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching users.";
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _userService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching user details.";
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersSaveDto user)
        {
            var response = await _userService.CreateAsync(user);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error creating user.";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _userService.GetByIdAsync(id);
            if (model != null)
            {
                return View(model.model);
            }

            ViewBag.Message = "Error fetching user for editing.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsersSaveDto user)
        {
            var response = await _userService.UpdateAsync(user);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error updating user.";
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.DeleteAsync(id);
            if (response != null && response.isSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Message = response?.message ?? "Error deleting user.";
            return RedirectToAction(nameof(Index));
        }
    }
}
