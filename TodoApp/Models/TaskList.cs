using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class TaskList
    {
        public int TaskListId { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

    }
}
