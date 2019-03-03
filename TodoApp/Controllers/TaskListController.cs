using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TaskListController(TodoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskList>> get()
        {
            return await _context.TaskLists.Include("Tasks").ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TaskList>> PostTaskList(TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskList", new { id = taskList.TaskListId }, taskList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskList>> GetTaskList(int id)
        {
            var taskList = await _context.TaskLists.Include("Tasks").Where(t => t.TaskListId == id).FirstAsync();

            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskList>> PutTaskList(long id, TaskList taskList)
        {
            if (id != taskList.TaskListId)
            {
                return BadRequest();
            }

            _context.Entry(taskList).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}