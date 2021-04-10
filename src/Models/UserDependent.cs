using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Boundless.Models
{
    public class UserDependent
    {
        public String Id { get; set; }
        [ForeignKey("Id")]
        public virtual IdentityUser IdentityUser { get; set; }
        public String RoleId { get; set; }
    }
}
