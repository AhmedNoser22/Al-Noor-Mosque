using Microsoft.EntityFrameworkCore;
namespace Al_Noor.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<IdentityRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<RoleDto>> GetAllRole()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleDtos = _mapper.Map<List<RoleDto>>(roles);
            return roleDtos;
        }
        public async Task<IdentityResult> CreateRole(RoleDto role)
        {
            bool roleExists =await _roleManager.RoleExistsAsync(role.Name);
            if (roleExists)
            {
                throw new Exception("Role already exists");
            }
            var mapdto = _mapper.Map<IdentityRole>(role);
            return await _roleManager.CreateAsync(mapdto);
        }
        public async Task<List<ManagerDto>> GetManagers(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found");
            }
            var users = await _userManager.Users.ToListAsync();
            var managers = new List<ManagerDto>();
            foreach (var user in users)
            {
                var managerUser = _mapper.Map<ManagerDto>(user);
                var isInRole = await _userManager.IsInRoleAsync(user, role.Name);
                managerUser.IsSelected = isInRole;
                managers.Add(managerUser);
            }
            return managers;
        }
        public async Task<IdentityResult> AddUserToRoleAsync(List<ManagerDto> managerUsers, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if(role==null)
            {
                throw new Exception("Role not found");
            }
            foreach (var item in managerUsers)
            {
                var user = await _userManager.FindByIdAsync(item.UserId);
                if (user == null)
                {
                    throw new Exception($"User with ID {item.UserId} not found");
                }
                if (item.IsSelected&&(!await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                    
                }
                else if(!item.IsSelected&& (await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return IdentityResult.Success;
        }

    }
}
