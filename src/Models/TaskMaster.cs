using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boundless.Models
{
    [Table("TaskMaster")]
    public class TaskMaster
    {
        [Key]
        public int TaskID { get; set; }

        [Required(ErrorMessage = "Enter Project Code")]
        public string ProjectCode { get; set; }
        
        [Required(ErrorMessage = "Enter ProjectName")]
        public string Name { get; set; }
        public string Notes { get; set; }
    }
}
