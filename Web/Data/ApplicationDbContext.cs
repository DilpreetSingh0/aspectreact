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
            builder.Entity<Project>().ToTable ("Project");
            builder.Entity<Membership>().HasOne(p => p.Project);
            base.OnModelCreating(builder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategory { get; set; }
        public DbSet<ProgressUpdate> ProgressUpdates { get; set; }
        public DbSet<ASPectLibrary.Course> Course { get; set; }

        public DbSet<Membership> Memberships { get; set; }
    }
}
