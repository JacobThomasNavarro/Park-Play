using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class RecommendedEventsViewModel
    {
        public List<Sport> Sports { get; set; }
        public List<SkillSportUser> SkillSportUsers { get; set; }
        public List<PlayEvent> PlayEvents { get; set; }
        public string ParkName { get; set; }
        public User User { get; set; }
    }
}