using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class childEnrolled
    {
        public int ID { get; set; }

        [Display(Name = "Activity")]
        public int ActID { get; set; }

        [Display(Name = "Child")]
        public int ChildID { get; set; }

        public virtual Activities Activities { get; set; }

        public virtual Child Child { get; set; }
    }
}
