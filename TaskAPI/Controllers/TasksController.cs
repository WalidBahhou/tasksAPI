using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Repositories;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly Repositories.ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        //[EnableCors("AllowOrigin")]
        public async Task<IEnumerable<TaskAPI.Model.Task>> GetTasks()
        {
            return await _taskRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAPI.Model.Task>> GetTasks(int id)
        {
            return await _taskRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<TaskAPI.Model.Task>>PostTasks([FromBody] TaskAPI.Model.Task task)
        {
            var newTask = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult>PutTasks(int id, [FromBody] TaskAPI.Model.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            await _taskRepository.Update(task);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var taskToDelete = await _taskRepository.Get(id);
            if (taskToDelete == null)
                return NotFound();

            await _taskRepository.Delete(taskToDelete.Id);
            return NoContent();
        }
    }
}