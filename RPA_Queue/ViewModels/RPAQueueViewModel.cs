using RPA_Queue.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RPA_Queue.ViewModels
{
    public class RPAQueueViewModel
    {
        public int Id { get; set; }

        [DisplayName("Project Name")]
        [Required(ErrorMessage = "Project Name is required!")]
        public string ProjectName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select group!")]
        public string Group { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select department!")]
        public string Department { get; set; }

        [DisplayName("Cost Center")]
        public int CostCenter { get; set; }

        [DisplayName("Process Owner")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Process Owner is required!")]
        public string ProcessOwner { get; set; }

        public string Account { get; set; }

        [DisplayName("License Type")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select license type!")]
        public string LicenseType { get; set; }

        public string Note { get; set; }

        [DisplayName("Development Status")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select development status!")]
        public string DevelopmentStatus { get; set; }

        public string Schedule { get; set; }

        [DisplayName("Running Times")]
        public string RunningTimes { get; set; }

        [DisplayName("Used Applications")]
        public string UsedApps { get; set; }

        [DisplayName("Developed On")]
        [Required(ErrorMessage = "Please enter date!")]
        public DateTime DevelopedOn { get; set; }

        // Inserting the "DropDownMenuItemsModel" inside the "RPAQeueuViewModel"
        // to be able to display everything in a single view. "DropDownMenuItemsModel"
        // is used to populate all dropdown menus on "Create" and "Edit" pages.
        public DropDownMenuItemsModel DropDownMenuItems { get; set; } = new();

    }
}
