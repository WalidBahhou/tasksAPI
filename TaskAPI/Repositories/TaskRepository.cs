using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAPI.Model;

namespace TaskAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;
        public TaskRepository(TaskContext context)
        {
            _context = context;
        }
        public async Task<Model.Task> Create(Model.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var taskToDelete = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Model.Task>> Get()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Model.Task> Get(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async System.Threading.Tasks.Task Update(Model.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            _context.Entry(task).CurrentValues.SetValues(task);

            await _context.SaveChangesAsync();
        }
    }
}
