using Boundless.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boundless.ViewModels
{
    public class TimeSheetData
    {
        public IEnumerable<TimeSheetMasterView> TimeSheetMasterView { get; set; }
        public IEnumerable<TimeSheetDetail> TimeSheetDetails { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Microsoft.AspNetCore.Identity.IdentityUser> Users { get; set; }
        public IEnumerable<ProjectMaster> Projects { get; set; }
        public IEnumerable<TaskMaster> Tasks { get; set; }
        public string Description { get; set; }
        public float Hours { get; set; }

    }
}
