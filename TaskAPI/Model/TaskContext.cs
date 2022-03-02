using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Model
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(LocalDb)\LocalDBDemo;Database=LocalTesting;Trusted_Connection=True");
        //}

        public DbSet<Task> Tasks { get; set; }
    }
}
