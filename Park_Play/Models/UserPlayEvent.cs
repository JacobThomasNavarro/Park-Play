using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class UserPlayEvent
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }

        [ForeignKey("PlayEvent")]
        public int PlayEventId { get; set; }
        public PlayEvent playEvent { get; set; }
    }
}