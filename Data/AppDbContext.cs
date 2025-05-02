using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Entities;

namespace To_Do_List.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){ }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Habit> Habits { get; set; }

        public DbSet<TaskTag> TaskTags { get; set; }
        public DbSet<TaskHabit> TaskHabits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-D416A0N;Database=ToDoListDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // map Task Priority enum to property as string
            modelBuilder.Entity<TaskItem>()
                .Property(ti => ti.Priority)
                .HasConversion<int>();


            // Shadow property
            modelBuilder.Entity<TaskItem>().Property<DateTime>("CreatedAt");


            // Task Tag with Tasks and Tags
            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskId, tt.TagId });

            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.TaskItem)
                .WithMany(ti => ti.TaskTags)
                .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<TaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TagId);

            // Task Habit with Tasks and Habits
            modelBuilder.Entity<TaskHabit>()
                .HasKey(th => new {th.TaskId, th.HabitId});

            modelBuilder.Entity<TaskHabit>()
                .HasOne(th => th.TaskItem)
                .WithMany(ti => ti.TaskHabits)
                .HasForeignKey(th => th.TaskId);

            modelBuilder.Entity<TaskHabit>()
                .HasOne(th => th.Habit)
                .WithMany(h => h.TaskHabits)
                .HasForeignKey(th => th.HabitId);


            // filtering
            modelBuilder.Entity<TaskHabit>().HasQueryFilter(th => !th.TaskItem.IsDeleted);
            modelBuilder.Entity<TaskTag>().HasQueryFilter(tt => !tt.TaskItem.IsDeleted);


            base.OnModelCreating(modelBuilder);

            SampleData.SeedData(modelBuilder);
        }
    }
}
