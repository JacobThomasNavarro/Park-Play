using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }

        public string sportName { get; set; }
    }
}