using System;

namespace StrengthCraft.Models
{
    public class Attendee
    {
        public DateTime RegistrationDate { get; set; }

        public int AttendeeId { get; set; }


        public string AttendeeName { get; set; }


        public string AttendeeLastName { get; set; }


        public int Weight { get; set; }


        public string EmailAddress { get; set; }


        public string YoutubeMovieUrl { get; set; }


        public string WorkoutDurationTime { get; set; }

        public bool IsVerified { get; set; }

        public Category Category { get; set; }
    }
}