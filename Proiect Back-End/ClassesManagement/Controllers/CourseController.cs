namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;

    [ApiController]
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseLogic _courseLogic;

        public CourseController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CourseDto courseDto)
        {
            _courseLogic.Create(courseDto);

            return Ok(courseDto);
        }
    }
}
