using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Entities
{
    public class TaskHabit
    {
        public int TaskId { get; set; }
        public TaskItem TaskItem { get; set; } = null!;

        public int HabitId { get; set; }
        public Habit Habit { get; set; } = null!;
    }
}
