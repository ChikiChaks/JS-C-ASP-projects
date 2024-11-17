using Programmin2_classroom.Shared.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.Models.Courses
{
    public class CourseAndTasks
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string Department { get; set; }
        public List<TaskNameWeight> Tasks { get; set; }
   
    }

}
