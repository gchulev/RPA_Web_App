using System.ComponentModel.DataAnnotations;

namespace RPA_Queue.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public string ReturnCode { get; set; }
    }
}
