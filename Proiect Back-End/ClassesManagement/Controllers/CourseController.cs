namespace ClassesManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLogic.ClassesManagement.Abstractions;
    using Entities.ClassesManagement;
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

        [HttpGet("{courseEntityId:guid}")]
        public CourseDto GetById([FromRoute] Guid courseEntityId)
        {
            var course = _courseLogic.GetById(courseEntityId);

            return course;
        }

        [HttpGet()]
        public IEnumerable<IGrouping<Guid, Course>> GetAll()
        {
            var courses = _courseLogic.GetAll();

            return courses;
        }

    }
}
