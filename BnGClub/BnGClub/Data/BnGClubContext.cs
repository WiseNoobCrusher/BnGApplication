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

        public DbSet<User> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<childEnrolled> childEnrolleds { get; set; }
        public DbSet<Activitys> Activities { get; set; }
        public DbSet<ActType> ActTypes { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<LeaderMessage> LeaderMessages { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BNG");

            modelBuilder.Entity<childEnrolled>()
                .HasKey(ce => new { ce.actID, ce.childID });

            modelBuilder.Entity<Subscriptions>()
                .HasKey(s => s.ID);

            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.userEmail })
                .IsUnique();

            modelBuilder.Entity<Leader>()
                .HasIndex(l => new { l.leaderEmail })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasMany<Child>(u => u.Childs)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Child>()
                .HasMany<childEnrolled>(c => c.ChildEnrolleds)
                .WithOne(ce => ce.Child)
                .HasForeignKey(ce => ce.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activitys>()
                .HasMany<childEnrolled>(a => a.ChildEnrolleds)
                .WithOne(ce => ce.Activitys)
                .HasForeignKey(ce => ce.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Activitys>()
                .HasMany<Announcement>(a => a.Announcements)
                .WithOne(an => an.Activitys)
                .HasForeignKey(an => an.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActType>()
                .HasMany<Activitys>(at => at.Activities)
                .WithOne(a => a.ActType)
                .HasForeignKey(a => a.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<LeaderMessage>(l => l.LeaderMessages)
                .WithOne(lm => lm.Leader)
                .HasForeignKey(lm => lm.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<Activitys>(l => l.Activities)
                .WithOne(a => a.Leader)
                .HasForeignKey(a => a.id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Leader>()
                .HasMany<Announcement>(l => l.Announcements)
                .WithOne(a => a.Leader)
                .HasForeignKey(a => a.id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
