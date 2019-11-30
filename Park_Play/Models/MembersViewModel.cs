using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class MembersViewModel
    {
        public List<User> UsersList { get; set; }
        public PlayEvent PlayEvent { get; set; }
    }
}