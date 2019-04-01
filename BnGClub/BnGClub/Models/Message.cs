using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Message : Auditable
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You must be sending this message to someone!")]
        [Display(Name = "To:")]
        public string msgTo { get; set; }

        [Required(ErrorMessage = "You must be sending this message to someone!")]
        [Display(Name = "From:")]
        public string msgFrom { get; set; }

        [Required(ErrorMessage = "You must be sending this message to someone!")]
        [Display(Name = "Message")]
        public string msgBody { get; set; }
    }
}
