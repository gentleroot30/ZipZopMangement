﻿using Microsoft.EntityFrameworkCore;
using ZipZop.Modals;

namespace ZipZop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
