using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodo.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Complete { get; set; }
        public int UserId { get; set; }
      
    }
}
