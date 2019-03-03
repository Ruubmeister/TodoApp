using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Task : BaseEntity
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? FinishedAt { get; set; }
        public int? ParentId { get; set; }

        public int TaskListId { get; set; }

        [ForeignKey("TaskListId")]
        public TaskList TaskList { get; set; }
    }
}
