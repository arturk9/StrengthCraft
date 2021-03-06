﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StrengthCraft.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}