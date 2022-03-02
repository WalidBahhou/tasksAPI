using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskAPI.Model.Task>> Get();
        Task<TaskAPI.Model.Task> Get(int id);
        Task<TaskAPI.Model.Task> Create(TaskAPI.Model.Task task);
        Task Update(TaskAPI.Model.Task task);
        Task Delete(int id);

    }
}
