using Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=Registration;Username=postgres;Password=mateusz98");
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecialization>().HasOne(s => s.User).WithOne(s => s.Specialization);
        }

    }
}
