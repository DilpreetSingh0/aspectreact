﻿using System;
using System.Collections.Generic;
using System.Text;
using ASPectLibrary;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating (ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<Project>().ToTable ("Project");
            builder.Entity<Membership>().HasOne(p => p.Project);
            //Defines a COMPOSITE KEY for Membership
            builder.Entity<Membership>()
                    .HasKey(c => new { c.StudentId, c.ProjectId });

            builder.Seed();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        public DbSet<ProgressUpdate> ProgressUpdates { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<ProjectRole> projectRoles { get; set; }
    }
}
