using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class LeaderMessage
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Message Date is required")]
        [Display(Name = "Date of Message")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime? msgDate { get; set; }

        [Required(ErrorMessage = "Message cannot be left blank.")]
        [Display(Name = "Message")]
        public string msgDescription { get; set; }

        [Display(Name = "Leader")]
        public int LeaderID { get; set; }

        public virtual Leader Leader { get; set; }
    }
}
