using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnGClub.Models
{
    public class childEnrolled
    {
        public int id { get; set; }

        public int actID { get; set; }

        public int childID { get; set; }

        public virtual Activitys Activitys { get; set; }

        public virtual Child Child { get; set; }
    }
}
