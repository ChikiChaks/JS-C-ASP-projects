using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.Models.Tasks
{
    public class TaskToAdd
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public double Weight { get; set; }
        public int TotalPages { get; set; }
        public int GroupSize { get; set; }
        public bool IsCompleted { get; set; }
        public int CourseID { get; set; }

    }
}
