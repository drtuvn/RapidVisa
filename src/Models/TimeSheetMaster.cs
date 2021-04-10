using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boundless.Models
{
    //[Table("TimeSheetMaster")]
    public class TimeSheetMaster
    {
        [Key]
        public int TimeSheetMasterID { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public float? TotalHours { get; set; }
        public string UserID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int TimeSheetStatus { get; set; }
        public string Comment { get; set; }
     
    }
}
