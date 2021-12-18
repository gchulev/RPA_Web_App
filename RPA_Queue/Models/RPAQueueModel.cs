using System;
using System.ComponentModel.DataAnnotations;

namespace RPA_Queue.Models
{
    public class RPAQueueModel
    {
        [Key]
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Group { get; set; }
        public string Department { get; set; }
        public int CostCenter { get; set; }
        public string ProcessOwner { get; set; }
        public string Account { get; set; }
        public string LicenseType { get; set; }
        public string Note { get; set; }
        public string DevelopmentStatus { get; set; }
        public string Schedule { get; set; }
        public string RunningTimes { get; set; }
        public string UsedApps { get; set; }
        public DateTime DevelopedOn { get; set; }
    }
}
