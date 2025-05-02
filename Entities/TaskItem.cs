using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Entities
{
    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class TaskItem
    {
       public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<TaskTag> TaskTags { get; set; } = new List<TaskTag>();
        public ICollection<TaskHabit> TaskHabits { get; set; } = new List<TaskHabit>();
        public DateTime CreatedAt { get; internal set; }
    }
}
