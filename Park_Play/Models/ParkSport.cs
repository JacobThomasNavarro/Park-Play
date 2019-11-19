using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class ParkSport
    {
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public Park park { get; set; }

        [ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport sport { get; set; }
    }
}