using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballClub.Models.Models.Club
{
    public class ClubCreateModel
    {
        [Required(ErrorMessage = "The Name for the Club is required")]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Owner for the Club is required")]
        [MaxLength(200)]
        public string Owner { get; set; }
        [Required(ErrorMessage = "The City for the Club is required")]
        [MaxLength(200)]
        public string City { get; set; }
        [Required(ErrorMessage = "The Country for the Club is required")]
        [MaxLength(200)]
        public string Country { get; set; }
    }
}
