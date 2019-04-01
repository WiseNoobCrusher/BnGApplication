using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BnGClub.Models;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace BnGClub.Data
{
    public class BnGClubContext : DbContext
    {
        public BnGClubContext (DbContextOptions<BnGClubContext> options)
            : base(options)
        {
            UserName = "SeedData";
        }

        public BnGClubContext(DbContextOptions<BnGClubContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            UserName = _httpContextAccessor.HttpContext?.User.Identity.Name;
            UserName = (UserName == null) ? "Unknown" : UserName;
        }

        private readonly IHttpContextAccessor _httpContextAccessor;

        public string UserName
        {
            get; private set;
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<childEnrolled> childEnrolleds { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<ActType> ActTypes { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Message> Messages { get; set; }
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

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is IAuditable trackable)
                {
                    var now = DateTime.UtcNow;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;

                        case EntityState.Added:
                            trackable.CreatedOn = now;
                            trackable.CreatedBy = UserName;
                            trackable.UpdatedOn = now;
                            trackable.UpdatedBy = UserName;
                            break;
                    }
                }
            }
        }
    }
}
