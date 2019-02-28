using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Models
{
    public class Comment : BaseEntity
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int TaskId { get; set; }
    }
}
