using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class UserSportViewModel
    {
        public List<Sport> SportList { get; set; }

        public List<SkillSportUser> sportSkillLevels { get; set; }
    }
}