using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class PlayEvent
    {
        [Key]
        
        public int PlayEventId { get; set; }

        [Required]
        [Display(Name = "Recommended Skill Level")]
        public int skillLevel { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:h:mm tt}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Number of Players")]
        public int numberOfPlayers { get; set; }

        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public Park Park { get; set; }

        [ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport Sport { get; set; }
    }
}