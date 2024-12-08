using GestionMedicaAPP.Application.Contracts.Users;
using GestionMedicaAPP.Application.Dtos.Users.users;
using GestionMedicaAPP.Persistance.Models.users;
using Microsoft.AspNetCore.Mvc;

namespace GestionMedicaAPP.Web.Controllers.users
{
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: UsersController/Index
        public async Task<IActionResult> Index()
        {
            var result = await _usersService.GetAll();
            if (result.IsSuccess)
            {
                List<UsersModel> userModels = (List<UsersModel>)result.Model;
                return View(userModels);
            }
            return View();
        }

        // GET: UsersController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _usersService.GetById(id);
            if (result.IsSuccess)
            {
                UsersModel userModel = (UsersModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersSaveDto userSaveDto)
        {
            try
            {
                var result = await _usersService.SaveAsync(userSaveDto);
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
                UsersModel userModel = (UsersModel)result.Model;
                return View(userModel);
            }
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsersUpdateDto userUpdateDto)
        {
            try
            {
                var result = await _usersService.UpdateAsync(userUpdateDto);
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