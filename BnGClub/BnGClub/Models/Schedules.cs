using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Schedules
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [Display(Name = "Starting Time")]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = false)]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "End Time is required")]
        [Display(Name = "Ending Time")]
        [DisplayFormat(DataFormatString = "{0:H:mm}", ApplyFormatInEditMode = false)]
        public DateTime endTime { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = false)]
        public DateTime dateAct { get; set; }

        [Required(ErrorMessage = "Activity is required")]
        [Display(Name = "Activity")]
        public int ActID { get; set; }

        public virtual Activities Activities { get; set; }
    }
}
