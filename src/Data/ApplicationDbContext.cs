using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Boundless.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Boundless.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<ProjectMaster> Project { get; set; }
        public DbSet<TaskMaster> Task { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Employee>().ToTable("Employee");
            //modelBuilder.Entity<Project>().ToTable("Project");
            //modelBuilder.Entity<Task>().ToTable("Task");
        }
        //public DbSet<Project> Projects { get; set; }
        public DbSet<Boundless.Models.Customer> Customer { get; set; }
        //public DbSet<Project> Projects { get; set; }
        public DbSet<Boundless.Models.TimeSheetMaster> TimeSheetMaster { get; set; }
        //public DbSet<Project> Projects { get; set; }
        public DbSet<Boundless.Models.TimeSheetDetail> TimeSheetDetail { get; set; }
    }
}
