using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Child
    {
        public Child()
        {
            this.ChildEnrolleds = new HashSet<childEnrolled>();
        }
        public int id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First Name cannot be more the 50 characters long.")]
        public string childFName { get; set; }

        [Display(Name = "Middle Name")]
        [Required(ErrorMessage = "You cannot leave the middle name blank.")]
        [StringLength(50, ErrorMessage = "Middle Name cannot be more the 50 characters long.")]
        public string childMName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(100, ErrorMessage = "Last Name cannot be more the 100 characters long.")]
        public string childLName { get; set; }

        [Required(ErrorMessage = "DOB is required")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? childDOB { get; set; }

        [Required(ErrorMessage = "User is required.")]
        [Display(Name = "Parent")]
        public int userID { get; set; }

        [Display(Name = "Parent")]
        public virtual User User { get; set; }

        public virtual ICollection<childEnrolled> ChildEnrolleds { get; set; }
    }
}
