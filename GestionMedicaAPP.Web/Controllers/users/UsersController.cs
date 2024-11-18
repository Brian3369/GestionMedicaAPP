using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _usersService.GetAll();
            if (result.IsSuccess)
            {
                List<UsersModel> usersModels = (List<UsersModel>)result.Model;
                return View(usersModels);
            }
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _usersService.GetById(id);
            if (result.IsSuccess)
            {
                UsersModel usersModels = (UsersModel)result.Model;
                return View(usersModels);
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersSaveDto usersSaveDto)
        {
            try
            {
                usersSaveDto.UpdatedAt = DateTime.Now;
                var result = await _usersService.SaveAsync(usersSaveDto);
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

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _usersService.GetById(id);
            if (result.IsSuccess)
            {
                UsersModel usersModels = (UsersModel)result.Model;
                return View(usersModels);
            }
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsersUpdateDto usersUpdateDto)
        {
            try
            {
                usersUpdateDto.UpdatedAt = DateTime.Now;
                var result = await _usersService.UpdateAsync(usersUpdateDto);
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

        // GET: UsersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _usersService.RemoveById(id);
            if (result.IsSuccess)
            {
                return View();
            }
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
