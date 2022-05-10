using System;
using System.Collections.Generic;
using System.Text;

namespace FootballClub.Models.Models.Player
{
    public class PlayerUpdateModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime SigningDate { get; set; }
        public int Rank { get; set; }
        public int TotalGoals { get; set; }
        public int ClubId { get; set; }
    }
}
