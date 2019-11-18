using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Park_Play.Models
{
    public class Park
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [Display(Name = "Park")]
        public string ParkName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [Display(Name = "State Code")]
        public string stateCode { get; set; }

        [Required]
        [Display(Name = "ZIP Code")]
        public int zipcode { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        public double ContactNumber { get; set; }

        public float lat { get; set; }
        public float lng { get; set; }
    }
}