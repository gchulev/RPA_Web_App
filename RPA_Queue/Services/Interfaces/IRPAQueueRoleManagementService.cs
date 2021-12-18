using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA_Queue.Services.Interfaces
{
    public interface IRPAQueueRoleManagementService
    {
        Task<string> CreateRoleAsync(string roleName);
        Task<IdentityRole> FindRoleByNameAsync(string roleName);
        Task<IdentityRole> FindRoleByIdAsync(string id);
        Task<IEnumerable<IdentityRole>> ListRolesAsync();
    }
}
