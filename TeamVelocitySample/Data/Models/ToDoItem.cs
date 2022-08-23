using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamVelocitySample.Data.Models
{
    public class ToDoItem
    {
        public int ToDoItemId { get; set; }
        public string Title { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
