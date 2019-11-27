using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Park_Play.Models
{
    public class ParkEventViewModel
    {
        public Park Park { get; set; }
        public List<Sport> SportsList { get; set; }
        public Sport Sport { get; set; }

        [Required]
        [Display(Name = "Recommended Skill Level")]
        public int skillLevel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Play Date")]
        public DateTime PlayDate { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        [Required]
        [Display(Name = "Number of Players")]
        public int numberOfPlayers { get; set; }
    }
}