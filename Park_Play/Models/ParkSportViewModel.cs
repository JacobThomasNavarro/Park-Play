using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class ParkSportViewModel
    {
       public string ParkName { get; set; }
       public List<Sport> SportsList { get; set; }
    }
}