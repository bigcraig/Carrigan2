using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<WebApplication2.Models.Company> Company { get; set; }
        public DbSet<WebApplication2.Models.TemperatureMeasurement> TemperatureMeasurement { get; set; }

        public DbSet<WebApplication2.Models.UserTask> UserTask { get; set; }
        public DbSet<WebApplication2.Models.Checklist> Checklist { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);  //needed since overiding model builder

            
                    
        }

        public DbSet<WebApplication2.Models.ComplianceRecord> ComplianceRecord { get; set; }

    }
}
