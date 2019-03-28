using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class ActType
    {
        public ActType()
        {
            this.Activities = new HashSet<Activities>();
        }

        public int ID { get; set; }

        [Required(ErrorMessage = "Activity Type Name cannot be left blank.")]
        [StringLength(100)]
        [Display(Name = "Type")]
        public string acttypeName { get; set; }

        [Required(ErrorMessage = "Activity Type Description cannot be left blank.")]
        [Display(Name = "Description")]
        public string acttypeDescription { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }
    }
}
