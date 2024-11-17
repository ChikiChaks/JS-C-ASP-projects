using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TriangleDbRepository;
using Programmin2_classroom.Shared.Models.Courses;
using Programmin2_classroom.Shared.Models.Tasks;

namespace Programmin2_classroom.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
        private readonly DbRepository _db;

        public CourseDetailsController(DbRepository db)
        {
            _db = db;
        }

        [HttpGet("allCourse")]
        public async Task<IActionResult> AllCoursesDetails()
        {
        
            object param = new { };

            string queryCourse = "SELECT C.CourseName, C.ID, count(T.TaskName) as TasksAmount FROM Courses AS C, Tasks AS T WHERE C.ID = T.CourseID GROUP BY C.CourseName, C.ID";

            var recordCourse = await _db.GetRecordsAsync<CourseInfo>(queryCourse, param);
            List<CourseInfo> courses = recordCourse.ToList();
            return Ok(courses);

        }

        [HttpGet("Course/{id}")]
        public async Task<IActionResult> CourseDetails(int ID)
        {
            object param = new
            {
                ID = ID
            };

            string queryCourse = "SELECT CourseName, Department, Credits, Year FROM Courses WHERE ID = @ID";
            string queryTasks = "SELECT TaskName, Weight, TotalPages, GroupSize FROM Tasks WHERE CourseID = @ID";

            var recordCourse = await _db.GetRecordsAsync<CourseStats>(queryCourse, param);
            CourseStats course = recordCourse.FirstOrDefault();

            var recordsTasks = await _db.GetRecordsAsync<TaskToAdd>(queryTasks, param);
            course.Tasks = recordsTasks.ToList();
            return Ok(course);

        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> updateFunc(int id, CourseToAdd newInfo)
        {
            object param = new
            {
                ID = id,
                CourseName = newInfo.CourseName,
                Department = newInfo.Department,
                Credits = newInfo.Credits,
                Year = newInfo.Year
            };
            string query = "UPDATE Courses SET CourseName = @CourseName,Year = @Year, Credits = @Credits WHERE ID = @ID";
            bool isUpdated = await _db.SaveDataAsync(query, param);
            if (isUpdated)
            {
                List<int> updateCheck = new List<int>();
                foreach (TaskToAdd task in newInfo.Tasks)
                {
                    object parameter = new
                    {
                        ID = task.ID,
                        TaskName = task.TaskName,
                        Weight = task.Weight,
                        TotalPages = task.TotalPages,
                        GroupSize = task.GroupSize,
                    };
                    string request = "UPDATE Tasks SET TaskName= @TaskName,Weight = @Weight, TotalPages = @TotalPages, GroupSize = @GroupSize WHERE ID = @ID";
                    bool taskUpdate = await _db.SaveDataAsync(request,parameter);
                    if (taskUpdate)
                    {
                        updateCheck.Add(task.ID);
                    }
                    else
                    {
                        return BadRequest("task not added");
                    }
                }
                if (updateCheck.Count == newInfo.Tasks.Count)
                {
                    return Ok("Updated successfuly");
                }
                return BadRequest("Update didn't work");
            }
            return BadRequest("did not start tasks update at all!");
        }


    }
}
