using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FootballClub.Data.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public DateTime SigningDate { get; set; }
        public int Rank { get; set; }
        public int TotalGoals { get; set; }
        public int ClubId { get; set; }
        [ForeignKey("ClubId")]
        public virtual Club Club { get; set; }
    }
}
