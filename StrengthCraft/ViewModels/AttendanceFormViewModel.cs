using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StrengthCraft.Models;

namespace StrengthCraft.ViewModels
{
    public class AttendanceFormViewModel
    {
        [Required]
        public string AttendeeName { get; set; }

        [Required]
        public string AttendeeLastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public string WorkoutDurationTime { get; set; }

        [Required]
        public string YoutubeMovieUrl { get; set; }

        public int Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}