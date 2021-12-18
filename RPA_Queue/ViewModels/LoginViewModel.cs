using RPA_Queue.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace RPA_Queue.ViewModels
{
    public class LoginViewModel : ApplicationUser
    {
        [Required(ErrorMessage = "Username field can not be empty!")]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Required(ErrorMessage = "Password field can not be empty!")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; } = false;
    }
}
