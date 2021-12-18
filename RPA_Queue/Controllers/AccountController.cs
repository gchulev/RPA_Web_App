using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPA_Queue.Models;
using RPA_Queue.Services.Interfaces;
using RPA_Queue.ViewModels;
using System.Threading.Tasks;

namespace RPA_Queue.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRPAQueueUserAuthenticationService _rPAQueueUserAuthenticationService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(IRPAQueueUserAuthenticationService rPAQueueUserAuthenticationService, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _rPAQueueUserAuthenticationService = rPAQueueUserAuthenticationService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        //GET: Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        //POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel viewModel, string returnUrl)
        {
            Task<bool> foundinADTask = _rPAQueueUserAuthenticationService.CheckIfUserCanAuthenticateAsync(viewModel.UserName, viewModel.Password);
            bool foundInAD = foundinADTask.Result;

            if (!foundInAD)
            {
                ModelState.AddModelError("", "Invalid username or password!");
            }

            if (ModelState.IsValid)
            {
                if (foundInAD)
                {
                    ApplicationUser userFound = await _userManager.FindByNameAsync(viewModel.UserName);

                    if (userFound != null)
                    {
                        ApplicationUser user = new()
                        {
                            UserName = viewModel.UserName,
                        };

                        await _signInManager.SignInAsync(user, viewModel.RememberMe);

                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return LocalRedirect(returnUrl);
                        }
                        return RedirectToAction("index", "RPAQueue");
                    }
                    else
                    {
                        ApplicationUser user = new()
                        {
                            UserName = viewModel.UserName,
                        };

                        await _signInManager.SignInAsync(user, viewModel.RememberMe);
                        IdentityResult result = await _userManager.CreateAsync(user);

                        if (result.Succeeded)
                        {
                            if (!string.IsNullOrEmpty(returnUrl))
                            {
                                return LocalRedirect(returnUrl);
                            }
                            return RedirectToAction("index", "RPAQueue");
                        }

                        ModelState.AddModelError("", $"Error Loggin in user: '{viewModel.UserName}', because the user could not be created in the local Database!");
                        return View(viewModel);
                    }
                }

                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View("Login", viewModel);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Home");
        }
    }
}
