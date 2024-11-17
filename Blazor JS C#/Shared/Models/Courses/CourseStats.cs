using Programmin2_classroom.Shared.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmin2_classroom.Shared.Models.Courses
{
    public class CourseStats
    {
        public string CourseName { get; set; }
        public string Department { get; set; }
        public double Credits { get; set; }
        public int Year { get; set; }
        public List<TaskToAdd> Tasks { get; set; }


    }

}
