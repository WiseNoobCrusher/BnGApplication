using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Announcement
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Message cannot be left blank.")]
        [Display(Name = "Message")]
        public string annMessage { get; set; }

        [Required(ErrorMessage = "Announcement Date is required")]
        [Display(Name = "Date Announced")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? annDate { get; set; }

        public int leaderID { get; set; }

        public int actID { get; set; }

        public virtual Leader Leader { get; set; }

        public virtual Activitys Activitys { get; set; }
    }
}
