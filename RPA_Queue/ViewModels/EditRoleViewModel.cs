using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA_Queue.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role name is required!")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new();
    }
}
