﻿
namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;
    using System;
    using System.Collections.Generic;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses/manage")]
    [ApiController]
    public class CourseManagementController : ControllerBase
    {
        private readonly ICourseManagementLogic _managementLogic;

        public CourseManagementController(ICourseManagementLogic managementLogic)
        {
            _managementLogic = managementLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManagementDto managementDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourseManagement = _managementLogic.Create(managementDto);

            return CreatedAtAction(nameof(GetById), new { CourseManagementEntityId = newCourseManagement.EntityId }, managementDto);

        }

        [HttpPut("{courseManagementEntityId:guid}")]
        public IActionResult Update([FromBody] ManagementDto managementDto, [FromRoute] Guid courseManagementEntityId)
        {
            var result = _managementLogic.Update(managementDto, courseManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{courseManagementEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid courseManagementEntityId)
        {
            var result = _managementLogic.Delete(courseManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{courseManagementEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid courseManagementEntityId)
        {
            var result = _managementLogic.GetById(courseManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<ManagementDto> GetAll()
        {
            var coursesManagements = _managementLogic.GetAll();

            return coursesManagements;
        }
    }
}