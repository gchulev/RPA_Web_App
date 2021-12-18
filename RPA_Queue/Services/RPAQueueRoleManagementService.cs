using Microsoft.AspNetCore.Identity;
using RPA_Queue.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPA_Queue.Services
{
    public class RPAQueueRoleManagementService : IRPAQueueRoleManagementService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RPAQueueRoleManagementService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<string> CreateRoleAsync(string roleName)
        {
            
            if (!await _roleManager.RoleExistsAsync(roleName.Trim()))
            {
                var role = new IdentityRole()
                {
                    Name = roleName
                };

                var taskResult =  await _roleManager.CreateAsync(role);
                
                if (taskResult.Succeeded)
                {
                    return "1"; //Return code '1' means successfully created.
                }

                return "2"; //Return code '2' means, failed to create role.
            }

            return "3"; //Return code '3' means, the role already exists in the database.
        }

        public async Task<IdentityRole> FindRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<IdentityRole> FindRoleByIdAsync(string id)
        {
            return await _roleManager.FindByIdAsync(id);
        }

        public async Task<IEnumerable<IdentityRole>> ListRolesAsync()
        {
            return _roleManager.Roles;
        }

    }
}
