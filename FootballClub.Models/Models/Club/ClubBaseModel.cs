using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Models.Models.Club
{
    public class ClubBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
