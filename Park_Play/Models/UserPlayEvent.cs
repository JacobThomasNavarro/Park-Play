using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class UserPlayEvent
    {
        [Key]
        public int UserPlayEventId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("PlayEvent")]
        public int PlayEventId { get; set; }
        public PlayEvent PlayEvent { get; set; }
    }
}