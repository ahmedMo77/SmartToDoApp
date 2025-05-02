using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List.Entities
{
    public class Habit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<TaskHabit> TaskHabits { get; set; } = new List<TaskHabit>();
    }
}
