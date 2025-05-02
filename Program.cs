using System;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Data;
using To_Do_List.Entities;

namespace To_Do_List
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();
            var taskService = new TaskService(context);

            while (true)
            {
                Console.WriteLine("\n=== TASK MANAGER ===");
                Console.WriteLine("1. View All Tasks");
                Console.WriteLine("2. Create New Task");
                Console.WriteLine("3. Assign Tag to Task");
                Console.WriteLine("4. Assign Habit to Task");
                Console.WriteLine("5. Mark Task as Completed");
                Console.WriteLine("6. Delete Task");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1": ViewTasks(context); break;
                    case "2": CreateTask(taskService); break;
                    case "3": AssignTag(taskService); break;
                    case "4": AssignHabit(taskService); break;
                    case "5": MarkTaskCompleted(context); break;
                    case "6": DeleteTask(taskService); break;
                    case "7": return;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        static void ViewTasks(AppDbContext context)
        {
            var tasks = context.Tasks
                .Include(t => t.TaskTags).ThenInclude(tt => tt.Tag)
                .Include(t => t.TaskHabits).ThenInclude(th => th.Habit)
                .ToList();

            Console.WriteLine("\n--- All Tasks ---");
            foreach (var task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate.ToShortDateString()}, Completed: {task.IsCompleted}");
                Console.WriteLine($"  Tags: {string.Join(", ", task.TaskTags.Select(tt => tt.Tag.Name))}");
                Console.WriteLine($"  Habits: {string.Join(", ", task.TaskHabits.Select(th => th.Habit.Name))}");
            }
        }

        static void CreateTask(TaskService taskService)
        {
            Console.Write("Title: ");
            var title = Console.ReadLine();
            Console.Write("Description: ");
            var description = Console.ReadLine();
            Console.Write("Due Date (yyyy-mm-dd): ");
            var dueDate = DateTime.Parse(Console.ReadLine()!);

            Console.WriteLine("Select Priority: 1. Low  2. Medium  3. High");
            var priority = (Priority)(int.Parse(Console.ReadLine()!) - 1);

            taskService.AddTask(title!, description!, dueDate, priority);
            Console.WriteLine("Task created successfully.");
        }

        static void AssignTag(TaskService taskService)
        {
            Console.Write("Task ID: ");
            int taskId = int.Parse(Console.ReadLine()!);
            Console.Write("Tag ID: ");
            int tagId = int.Parse(Console.ReadLine()!);

            taskService.AssignTag(taskId, tagId);
            Console.WriteLine("Tag assigned.");
        }

        static void AssignHabit(TaskService taskService)
        {
            Console.Write("Task ID: ");
            int taskId = int.Parse(Console.ReadLine()!);
            Console.Write("Habit ID: ");
            int habitId = int.Parse(Console.ReadLine()!);

            taskService.AssignHabit(taskId, habitId);
            Console.WriteLine("Habit assigned.");
        }

        static void MarkTaskCompleted(AppDbContext context)
        {
            Console.Write("Enter Task ID to mark complete: ");
            int taskId = int.Parse(Console.ReadLine()!);

            var task = context.Tasks.Find(taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                context.SaveChanges();
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static void DeleteTask(TaskService taskService)
        {
            Console.Write("Enter Task ID to delete: ");
            int taskId = int.Parse(Console.ReadLine()!);
            taskService.DeleteTask(taskId);
            Console.WriteLine("Task deleted.");
        }

    }
}
