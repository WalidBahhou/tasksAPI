using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; }
    }
}
