
namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;

    [Route("api/course/manage")]
    [ApiController]
    public class CourseManagementWriteController : ControllerBase
    {
        private readonly ICourseManagementLogic _managementLogic;

        public CourseManagementWriteController(ICourseManagementLogic managementLogic)
        {
            _managementLogic = managementLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManagementDto managementDto)
        {
            _managementLogic.Create(managementDto);

            return Ok(managementDto);
        }
    }
}