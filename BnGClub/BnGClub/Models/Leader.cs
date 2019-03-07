﻿using System;
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
            this.Activities = new HashSet<Activitys>();
            this.LeaderMessages = new HashSet<LeaderMessage>();
            this.Announcements = new HashSet<Announcement>();
        }

        public int id { get; set; }

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

        public virtual ICollection<Activitys> Activities { get; set; }

        public virtual ICollection<LeaderMessage> LeaderMessages { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
