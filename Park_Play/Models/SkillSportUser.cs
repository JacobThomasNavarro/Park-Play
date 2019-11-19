using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class SkillSportUser
    {
        public int skillLevel { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        [ForeignKey("Sport")]
        public int SportId { get; set; }
        public Sport sport { get; set; }
    }
}