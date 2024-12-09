//using GestionMedicaAPP.Application.Dtos.Users.users;
//using Microsoft.AspNetCore.Mvc;

//namespace GestionMedicaAPP.Web.Controllers
//{
//    public class UsersAdmController : Controller
//    {
//        private readonly IUsersApiService _usersService;

//        public UsersAdmController(IUsersApiService usersService)
//        {
//            _usersService = usersService;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var users = await _usersService.GetAllAsync();
//            return View(users);
//        }

//        public async Task<IActionResult> Details(int id)
//        {
//            var user = await _usersService.GetByIdAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return View(user);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(UsersSaveDto user)
//        {
//            if (!ModelState.IsValid) return View(user);

//            var result = await _usersService.CreateAsync(user);

//            if (!result.IsSuccess)
//            {
//                ViewBag.Message = result.Message;
//                return View();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Edit(int id)
//        {
//            var user = await _usersService.GetByIdAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return View(user);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, UsersSaveDto user)
//        {
//            if (!ModelState.IsValid) return View(user);

//            var result = await _usersService.UpdateAsync(id, user);

//            if (!result.IsSuccess)
//            {
//                ViewBag.Message = result.Message;
//                return View();
//            }
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int id)
//        {
//            var user = await _usersService.GetByIdAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return View(user);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var result = await _usersService.DeleteAsync(id);
//            if (!result.IsSuccess)
//            {
//                ViewBag.Message = result.Message;
//                return View();
//            }
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
