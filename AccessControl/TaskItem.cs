using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessControl
{
    public class TaskItem
    {
        public int id { get; set; }
        public DateOnly dueDate { get; set; } // DateTime or DateOnly 

        public String desc { get; set; }

        public TaskItem(int id, string desc, DateOnly dueDate)
        {
            this.id = id;
            this.desc = desc;
            this.dueDate = dueDate;
        }
    }
}
