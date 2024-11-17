using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleDbRepository;
using Programmin2_classroom.Shared.Models.Courses;
using Programmin2_classroom.Shared.Models.Tasks;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTasksController : ControllerBase
    {
        private readonly DbRepository _db;

        public CourseTasksController(DbRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseCountTasks()
        {
            object param = new { };

            string query = "SELECT C.CourseName || \", \" || C.Department AS CourseAndDepartment, Count(*) AS CourseCountAllTasks FROM Courses AS C, Tasks AS T WHERE C.ID = T.CourseID GROUP BY C.CourseName";

            var records = await _db.GetRecordsAsync<CourseCountTask>(query, param);
            List<CourseCountTask> courses = records.ToList();
            return Ok(courses);
        }
        [HttpGet("Tasks/{id}")]
        public async Task<IActionResult> GetTasks(int id)
        {
            object param = new
            {
                ID = id
            };

            string queryCourse = "SELECT ID, CourseName, Department FROM Courses WHERE ID = @ID";
            string queryTasks = "SELECT TaskName, Weight FROM Tasks WHERE CourseID = @ID";

            var recordCourse = await _db.GetRecordsAsync<CourseAndTasks>(queryCourse, param);
            CourseAndTasks course = recordCourse.FirstOrDefault();

            var recordsTasks = await _db.GetRecordsAsync<TaskNameWeight>(queryTasks, param);
            course.Tasks = recordsTasks.ToList();
            return Ok(course);

        }
        [HttpPost("add")]
        public async Task<IActionResult> InsertCourse(CourseToAdd newCourse)
        {
            string insertCourseQuery = "INSERT INTO Courses (CourseName, Department, Credits, Year) VALUES (@CourseName, @Department, @Credits, @Year)";
            int newCourseId = await _db.InsertReturnId(insertCourseQuery, newCourse);

            if (newCourseId > 0)
            {
                List<int> newTasksIds = new List<int>();

                foreach(TaskToAdd task in newCourse.Tasks)
                {
                    task.CourseID = newCourseId;
                    string insertTaskQuery = "INSERT INTO Tasks (TaskName, Weight, TotalPages, GroupSize, IsCompleted, CourseID) VALUES (@TaskName, @Weight, @TotalPages, @GroupSize, @IsCompleted, @CourseID)";
                    int newTaskId = await _db.InsertReturnId(insertTaskQuery, task);

                    if (newTaskId > 0)
                    {
                        newTasksIds.Add(newTaskId);
                    }
                }
                if (newTasksIds.Count == newCourse.Tasks.Count)
                {
                    return Ok(newCourseId);
                }
                int diff = newCourse.Tasks.Count - newTasksIds.Count;
                return BadRequest(diff.ToString() + "tasks failed");
            }
            return BadRequest("Error");
        }
    }
}
