using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class SportSkill
    {
        public List<Sport> Sports { get; set; }
        public List<SkillSportUser> SkillSportUsers { get; set; }
    }
}