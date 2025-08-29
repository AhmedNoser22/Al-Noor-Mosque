namespace Al_Noor.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public AuthServices(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        public async Task<bool> RegisterAsync(RegisterDto register)
        {
            var email = await _userManager.FindByEmailAsync(register.Email);
            if (email != null)
            {
                return false; // Email already exists
            }
            var user = _mapper.Map<AppUser>(register);
            var result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
            {
               // await _userManager.AddToRoleAsync(user,"User");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return true;
            }
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
            return false;

        }
        public async Task<bool> LoginAsync(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                return false; // User not found
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, lockoutOnFailure: false);
            return result.Succeeded;

        }
        public Task LogoutAsync()
        {
            return _signInManager.SignOutAsync(); // Sign out the user
        }
    }
}
