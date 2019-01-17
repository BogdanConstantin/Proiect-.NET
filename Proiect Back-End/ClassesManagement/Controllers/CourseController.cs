namespace ClassesManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using BusinessLogic.ClassesManagement.Abstractions;
    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/courses")]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCourse = _courseLogic.Create(courseDto);

            return CreatedAtAction(nameof(GetById), new { courseEntityId = newCourse.EntityId }, courseDto);
        }

        [HttpPut("{courseEntityId:guid}")]
        public IActionResult Update([FromBody] CourseDto courseDto, [FromRoute] Guid courseEntityId)
        {
            var result = _courseLogic.Update(courseDto, courseEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{courseEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid courseEntityId)
        {
            var result = _courseLogic.Delete(courseEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{courseEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid courseEntityId)
        {
            var result = _courseLogic.GetById(courseEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<CourseDto> GetAll()
        {
            var courses = _courseLogic.GetAll();

            return courses;
        }

    }
}
