
namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;
    using System;

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

        [HttpPut("{courseManagementEntityId:guid}")]
        public IActionResult Update([FromBody] ManagementDto managementDto, [FromRoute] Guid courseManagementEntityId)
        {
            _managementLogic.Update(managementDto, courseManagementEntityId);

            return NoContent();
        }

        [HttpDelete("{courseManagementEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid courseManagementEntityId)
        {
            _managementLogic.Delete(courseManagementEntityId);

            return NoContent();
        }
    }
}