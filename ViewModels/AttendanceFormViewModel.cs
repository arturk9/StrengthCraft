using System.Collections.Generic;
using StrengthCraft.Models;

namespace StrengthCraft.ViewModels
{
    public class AttendanceFormViewModel
    {
        public string AttendeeName { get; set; }
        public string AttendeeLastName { get; set; }
        public string EmailAddress { get; set; }
        public int Weight { get; set; }
        public string WorkoutDurationTime { get; set; }
        public string YoutubeMovieUrl { get; set; }
        public int Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}