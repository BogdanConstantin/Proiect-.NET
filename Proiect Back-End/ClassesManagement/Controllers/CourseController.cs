namespace ClassesManagement.Controllers
{
    using System;

    using BusinessLogic.ClassesManagement.Abstractions;

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

        [HttpPut("{courseEntityId:guid}")]
        public IActionResult Update([FromBody] CourseDto courseDto, [FromRoute] Guid courseEntityId)
        {
            _courseLogic.Update(courseDto, courseEntityId);

            return NoContent();
        }

        [HttpDelete("{courseEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid courseEntityId)
        {
            _courseLogic.Delete(courseEntityId);

            return NoContent();
        }

    }
}
