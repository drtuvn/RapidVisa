using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boundless.Models
{
    //[Table("TimeSheetDetails")]
    public class TimeSheetDetail
    {
        [Key]
        public int TimeSheetID { get; set; }
        public string DaysofWeek { get; set; }
        public float? Hours { get; set; }
        public DateTime? Period { get; set; }
        public int? ProjectID { get; set; }
        public string UserID { get; set; }
        public int? TaskID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int TimeSheetMasterID { get; set; }
       
    }
}
