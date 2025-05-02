using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List.Data;
using To_Do_List.Entities;

namespace To_Do_List
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public void AddTask(string title, string description, DateTime dueDate, Priority priority)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.");

            var task = new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                IsCompleted = false
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void AssignTag(int taskId, int tagId)
        {
            var task = _context.Tasks.Find(taskId);
            var tag = _context.Tags.Find(tagId);
            if (task == null || tag == null)
            {
                Console.WriteLine("Task or Tag not found.");
                return;
            }

            _context.TaskTags.Add(new TaskTag { TaskId = taskId, TagId = tagId });
            _context.SaveChanges();
        }


        public void AssignHabit(int taskId, int habitId)
        {
            var task = _context.Tasks.Find(taskId);
            var habit = _context.Habits.Find(habitId);
            if (task == null || habit == null)
            {
                Console.WriteLine("Task or Habit not found.");
                return;
            }

            _context.TaskHabits.Add(new TaskHabit { TaskId = taskId, HabitId = habitId });
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                task.IsDeleted = true;
                _context.SaveChanges();
            }
        }

    }

}
