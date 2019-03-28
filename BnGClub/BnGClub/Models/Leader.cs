using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Leader
    {
        public Leader()
        {
            this.Activities = new HashSet<Activities>();
            this.Announcements = new HashSet<Announcement>();
            this.Subscriptions = new HashSet<Subscriptions>();
        }

        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return leaderFName
                    + (string.IsNullOrEmpty(leaderMName) ? " " :
                      (" " + (char?)leaderMName[0] + ". ").ToUpper())
                    + leaderLName;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First Name cannot be more the 50 characters long.")]
        public string leaderFName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "You cannot leave the middle name blank.")]
        [StringLength(50, ErrorMessage = "Middle Name cannot be more the 50 characters long.")]
        public string leaderMName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last Name cannot be more the 100 characters long.")]
        public string leaderLName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string leaderEmail { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number. (No spaces)")]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 leaderPhone { get; set; }

        public virtual ICollection<Activities> Activities { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
