using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class User
    {
        public User()
        {
            this.Childs = new HashSet<Child>();
            this.Subscriptions = new HashSet<Subscriptions>();
        }

        public int ID { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return userFName
                    + (string.IsNullOrEmpty(userMName) ? " " :
                      (" " + (char?)userMName[0] + ". ").ToUpper())
                    + userLName;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First Name cannot be more the 50 characters long.")]
        public string userFName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "You cannot leave the middle name blank.")]
        [StringLength(50, ErrorMessage = "Middle Name cannot be more the 50 characters long.")]
        public string userMName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last Name cannot be more the 100 characters long.")]
        public string userLName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string userEmail { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number. (No spaces)")]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        public Int64 userPhone { get; set; }

        public virtual ICollection<Child> Childs { get; set; }

        public ICollection<Subscriptions> Subscriptions { get; set; }
    }
}
