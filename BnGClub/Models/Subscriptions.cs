using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class Subscriptions
    {
        public int ID { get; set; }

        [StringLength(127)]
        public string Name { get; set; }

        [StringLength(512)]
        public string PushEndpoint { get; set; }

        [StringLength(512)]
        public string PushP256DH { get; set; }

        [StringLength(512)]
        public string PushAuth { get; set; }

        [Display(Name = "Leader")]
        public int? LeaderID { get; set; }
        public Leader Leader { get; set; }

        [Display(Name = "Parent")]
        public int? UserID { get; set; }
        public Users User { get; set; }
    }
}
