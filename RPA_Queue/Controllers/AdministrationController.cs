using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPA_Queue.Models;
using RPA_Queue.Services.Interfaces;
using RPA_Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPA_Queue.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IRPAQueueRoleManagementService _roleManagementService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdministrationController(IRPAQueueRoleManagementService roleManagementService, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManagementService = roleManagementService;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                string returnCode = await _roleManagementService.CreateRoleAsync(createRoleViewModel.RoleName);
                ViewBag.RoleCreationResult = returnCode;
                ViewBag.RoleName = createRoleViewModel.RoleName;

                //Using return code to mark the different states of the response, 1 - Success, 2 - Failure, 3 - Already exists.
                switch (returnCode)
                {
                    case "1":
                        ModelState.Clear();
                        createRoleViewModel.RoleName = string.Empty;
                        return RedirectToAction("ListRoles", "Administration");
                    case "2":
                        return View(createRoleViewModel);
                    case "3":
                        ModelState.Clear();
                        createRoleViewModel.RoleName = string.Empty;
                        return View(createRoleViewModel);
                    default:
                        break;
                }
            }

            return View(createRoleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListRoles()
        {
            IEnumerable<IdentityRole> roles = await _roleManagementService.ListRolesAsync();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManagementService.FindRoleByIdAsync(id);
            if (ModelState.IsValid)
            {
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role: '{id}' not found";
                    return View("Error");
                }
            }

            var editRoleViewModel = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            foreach (ApplicationUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, editRoleViewModel.RoleName))
                {
                    editRoleViewModel.Users.Add(user.UserName);
                }
            }

            return View(editRoleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel viewModel)
        {
            var role = await _roleManager.FindByIdAsync(viewModel.Id);

            if (role == null)
            {
                ModelState.AddModelError("", $"Role Not found in the Database. Role with Id: {viewModel.Id} doesn't exist");
                return View(viewModel);
            }

            else
            {
                role.Name = viewModel.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(viewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = _roleManagementService.FindRoleByIdAsync(roleId).Result;
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                else
                {
                    var error = new ErrorViewModel();
                    return RedirectToAction("Error", error);
                }
            }
            else
            {
                ModelState.AddModelError("", "Role not found!");
                return View("ListRoles", _roleManager.Roles);
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddUserInRole(string roleId)//TODO: this Action method has to be re-worked to add users to the role not to show list of users
        {
            ViewBag.roleId = roleId;

            if (roleId != null)
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    var error = new ErrorViewModel()
                    {
                        ErrorMessage = $"Role with Id = {roleId} not found!"
                    };
                    return View("Error", error);
                }
                var userList = new List<AddUserInRoleViewModel>();

                foreach (var user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        var usersRoleViewModel = new AddUserInRoleViewModel
                        {
                            UserId = user.Id,
                            UserName = user.UserName
                        };
                        userList.Add(usersRoleViewModel);
                    }
                }
                return View();
            }
            return View();
        }
        //TODO: Http Post method for EditUserInRole action
        [HttpGet]
        public async Task<IActionResult> SearchUser(string searchUser)
        {
            var usersRoleViewModel = new AddUserInRoleViewModel();

            if (searchUser != null)
            {
                var user = await _userManager.FindByNameAsync(searchUser);
                if (user == null)
                {
                    usersRoleViewModel.UserName = searchUser;
                }
                else
                {
                    usersRoleViewModel = new AddUserInRoleViewModel() { UserName = user.UserName, UserId = user.Id };
                }
            }
            return View(usersRoleViewModel);
        }
    }
}
