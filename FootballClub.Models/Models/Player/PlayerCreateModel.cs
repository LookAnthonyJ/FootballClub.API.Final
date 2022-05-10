using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FootballClub.Models.Models.Player
{
    public class PlayerCreateModel
    {
        [Required(ErrorMessage = "The First Name for the Player is required")]
        [MaxLength(200)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name for the Player is required")]
        [MaxLength(400)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Date of Birth for the Player is required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "The Signing Date for the Player is required")]
        public DateTime SigningDate { get; set; }
        [Required(ErrorMessage = "The Rank for the Player is required")]
        public int Rank { get; set; }
        [Required(ErrorMessage = "The Total Goals for the Player is required")]
        public int TotalGoals { get; set; }
        [Required(ErrorMessage = "The ClubId for the Player is required")]
        public int ClubId { get; set; }
    }
}
