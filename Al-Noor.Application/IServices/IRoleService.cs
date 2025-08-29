using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Noor.Application.IServices
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetAllRole();
        Task<IdentityResult> CreateRole(RoleDto role);
        Task<List<ManagerDto>> GetManagers(string id);
        Task<IdentityResult> AddUserToRoleAsync(List<ManagerDto> managerUsers, string roleId);

    }
}
