using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RPA_Queue.Models
{
    //TODO: Re-work this to use DB instead of hard coded values in this class. Also make a functionality
    //where admins will be able to edit and Add/Remove items from the below lists.
    public class DropDownMenuItemsModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an option!")]
        public List<string> GroupItems { get; set; } = new()
        {
            "PD BMS",
            "PD Engines",
            "PD Components"
        };

        public List<int> CostCenterItems { get; set; } = new()
        {
            303350,
            330300,
            333333,
            222222
        };

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an option!")]
        public List<string> LicenseTypeItems { get; set; } = new ()
        {
            "Attended",
            "Unattended"
        };
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an option!")]
        public List<string> DevelopmentStatus { get; set; } = new()
        {
            "In Development",
            "In Production",
            "Testing"
        };
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select an option!")]
        public List<string> Department { get; set; } = new()
        {
            "OMM",
            "OPE",
            "IT",
            "OFC",
            "LCS",
            "LSCS",
            "HR",
        };
    }
}
