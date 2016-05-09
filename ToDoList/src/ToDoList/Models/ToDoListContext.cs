using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoListContext : DbContext
    {
        public virtual DbSet<Item> Items { get; set; }
    }
}
