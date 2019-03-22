using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BnGClub.Models;

namespace BnGClub.Data
{
    public class BnGClubContext : DbContext
    {
        public BnGClubContext (DbContextOptions<BnGClubContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<childEnrolled> childEnrolleds { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<ActType> ActTypes { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<LeaderMessage> LeaderMessages { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BNG");

            modelBuilder.Entity<childEnrolled>()
                .HasKey(ce => new { ce.ActID, ce.ChildID });

            modelBuilder.Entity<Subscriptions>()
                .HasKey(s => s.ID);

            modelBuilder.Entity<Users>()
                .HasIndex(u => new { u.userEmail })
                .IsUnique();

            modelBuilder.Entity<Leader>()
                .HasIndex(l => new { l.leaderEmail })
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasMany<Child>(u => u.Children)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Child>()
                .HasMany<childEnrolled>(c => c.ChildEnrolleds)
                .WithOne(ce => ce.Child)
                .HasForeignKey(ce => ce.ChildID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activities>()
                .HasMany<childEnrolled>(a => a.ChildEnrolleds)
                .WithOne(ce => ce.Activities)
                .HasForeignKey(ce => ce.ActID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activities>()
                .HasMany<Announcement>(a => a.Announcements)
                .WithOne(an => an.Activities)
                .HasForeignKey(an => an.ActID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActType>()
                .HasMany<Activities>(at => at.Activities)
                .WithOne(a => a.ActType)
                .HasForeignKey(a => a.ActTypeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<LeaderMessage>(l => l.LeaderMessages)
                .WithOne(lm => lm.Leader)
                .HasForeignKey(lm => lm.LeaderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<Activities>(l => l.Activities)
                .WithOne(a => a.Leader)
                .HasForeignKey(a => a.LeaderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<Announcement>(l => l.Announcements)
                .WithOne(a => a.Leader)
                .HasForeignKey(a => a.LeaderID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activities>()
                .HasMany<Schedules>(a => a.Schedules)
                .WithOne(s => s.Activities)
                .HasForeignKey(s => s.ActID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
