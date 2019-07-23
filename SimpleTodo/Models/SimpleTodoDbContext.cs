using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleTodo.Models;

namespace SimpleTodo.Models
{
    public class SimpleTodoDbContext : DbContext
    {
        public SimpleTodoDbContext() { }    
        public SimpleTodoDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=SimpleTodo;Integrated Security=SSPI");
            base.OnConfiguring(
                optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<List> Lists { get; set; }

    }
}
