using Microsoft.AspNetCore.Mvc;

namespace Al_Noor_Mosque.Controllers
{
    public class RolesController(IMapper mapper, IRoleService service) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var roles = await service.GetAllRole();
            var roleDtos = mapper.Map<List<GetRoleVM>>(roles);
            return View(roleDtos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddRoleVM role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            var MapVM = mapper.Map<RoleDto>(role);
            var result = await service.CreateRole(MapVM);
            if (result.Succeeded)
            {
                TempData["Success"] = "Role created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(role);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetManagers(string id)
        {
            var managers = await service.GetManagers(id);
            var managerDtos = mapper.Map<List<ManagerVM>>(managers);
            ViewBag.RoleId = id;
            return View(managerDtos);
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(List<ManagerVM> managerUsers, string roleId)
        {
            if (!ModelState.IsValid)
            {
                return View(managerUsers);
            }
            var mapDto = mapper.Map<List<ManagerDto>>(managerUsers);
            var result = await service.AddUserToRoleAsync(mapDto, roleId);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(managerUsers);
            }
        }
    }
}
