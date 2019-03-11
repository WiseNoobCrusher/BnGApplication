using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Activitys
    {
        public Activitys()
        {
            this.ChildEnrolleds = new HashSet<childEnrolled>();
            this.Announcements = new HashSet<Announcement>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Activity Name cannot be blank.")]
        [StringLength(100)]
        [Display(Name = "Name of Activity")]
        public string actName { get; set; }

        [Required(ErrorMessage = "Activity Description cannot be blank.")]
        [Display(Name = "Description")]
        public string actDescription { get; set; }

        [Required(ErrorMessage = "Activity Code cannot be left blank.")]
        [StringLength(10)]
        [Display(Name = "Code")]
        public string actCode { get; set; }

        [Required(ErrorMessage = "Activity Requirements cannot be left blank.")]
        [StringLength(10)]
        [Display(Name = "Requirement")]
        public string actRequirement { get; set; }

        [Required(ErrorMessage = "Available Place cannot be left blank.")]
        [StringLength(10)]
        [Display(Name = "Location")]
        public string actAvailablePlace { get; set; }

        public int leaderID { get; set; }

        public int acttypeID { get; set; }

        public virtual Leader Leader { get; set; }

        public virtual ActType ActType { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public virtual ICollection<childEnrolled> ChildEnrolleds { get; set; }
    }
}
