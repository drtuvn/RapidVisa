using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boundless.Models
{
    [NotMapped]
    public class TimeSheetMasterView
    {
        public int TimeSheetMasterID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public float? TotalHours { get; set; }
        public string UserID { get; set; }
        public string CreatedOn { get; set; }
        public string Username { get; set; }
        public string SubmittedMonth { get; set; }
        public string TimeSheetStatus { get; set; }
        public string Comment { get; set; }
    }
}
