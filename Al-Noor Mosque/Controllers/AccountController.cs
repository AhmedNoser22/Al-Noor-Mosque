namespace Al_Noor_Mosque.Controllers
{
    public class AccountController(IAuthServices services, IMapper mapper) : Controller
    {
        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegister register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var registerDto = mapper.Map<RegisterDto>(register);
            var result = await services.RegisterAsync(registerDto);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "حدث خطأ أثناء التسجيل");
            return View(register);
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var loginDto = mapper.Map<LoginDto>(login);
            var result = await services.LoginAsync(loginDto);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "اسم المستخدم أو كلمة المرور غير صحيحة");
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await services.LogoutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
