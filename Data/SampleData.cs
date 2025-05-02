using Microsoft.EntityFrameworkCore;
using System;
using To_Do_List.Entities;

namespace To_Do_List.Data
{
    public static class SampleData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "Work" },
                new Tag { Id = 2, Name = "Health" },
                new Tag { Id = 3, Name = "Personal" },
                new Tag { Id = 4, Name = "Urgent" }
            );

            modelBuilder.Entity<Habit>().HasData(
                new Habit { Id = 1, Name = "Exercise" },
                new Habit { Id = 2, Name = "Reading" },
                new Habit { Id = 3, Name = "Journaling" },
                new Habit { Id = 4, Name = "Planning" }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Finish project report",
                    Description = "Complete the project report by Friday.",
                    DueDate = new DateTime(2025, 5, 3),
                    CreatedAt = new DateTime(2025, 4, 30),
                    Priority = Priority.High,
                    IsCompleted = false,
                    IsDeleted = false
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Finish software project",
                    Description = "Complete this project by Friday.",
                    DueDate = new DateTime(2025, 5, 1),
                    CreatedAt = new DateTime(2025, 4, 28),
                    Priority = Priority.Medium,
                    IsCompleted = false,
                    IsDeleted = false
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Read Book",
                    Description = "Read 20 pages of 'Atomic Habits'.",
                    DueDate = new DateTime(2025, 5, 3),
                    CreatedAt = new DateTime(2025, 4, 29),
                    Priority = Priority.Low,
                    IsCompleted = false,
                    IsDeleted = false
                },
                new TaskItem
                {
                    Id = 4,
                    Title = "Team Meeting",
                    Description = "Zoom call with product team.",
                    DueDate = new DateTime(2025, 5, 1),
                    CreatedAt = new DateTime(2025, 4, 30),
                    Priority = Priority.High,
                    IsCompleted = false,
                    IsDeleted = false
                }
            );

            modelBuilder.Entity<TaskTag>().HasData(
                new TaskTag { TaskId = 1, TagId = 1 },
                new TaskTag { TaskId = 1, TagId = 4 },
                new TaskTag { TaskId = 2, TagId = 2 },
                new TaskTag { TaskId = 3, TagId = 3 },
                new TaskTag { TaskId = 4, TagId = 1 },
                new TaskTag { TaskId = 4, TagId = 4 }
            );

            modelBuilder.Entity<TaskHabit>().HasData(
                new TaskHabit { TaskId = 1, HabitId = 1 },
                new TaskHabit { TaskId = 2, HabitId = 1 },
                new TaskHabit { TaskId = 3, HabitId = 2 },
                new TaskHabit { TaskId = 4, HabitId = 4 }
            );
        }
    }
}
