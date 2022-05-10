using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballClub.Data.Entities
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Player> Players { get; set; }
    }
}
