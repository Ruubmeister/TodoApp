using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne(c => c.TaskList)
                .WithMany(e => e.Tasks);
        }

        public virtual DbSet<Models.Task> Tasks { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<TaskList> TaskLists{ get; set; }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnBeforeSaving()
        {

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity trackable)
                {
                    var now = DateTime.UtcNow;

                    trackable.UpdatedAt = now;

                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.CreatedAt = entry.GetDatabaseValues().GetValue<DateTime>("CreatedAt");
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;

                            break;
                    }
                }
            }
        }
    }
}
