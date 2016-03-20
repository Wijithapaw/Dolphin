using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Domain.Entities
{
    public class Donor : User
    {
        [Display(Name = "Administrator")]
        public bool IsAdmin { get; set; }
    }
}
