namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;
    using System;
    using System.Collections.Generic;

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/laboratories/manage")]
    
    public class LaboratoryManagementController : ControllerBase
    {
        private readonly ILaboratoryManagementLogic _managementLogic;

        public LaboratoryManagementController(ILaboratoryManagementLogic managementLogic)
        {
            _managementLogic = managementLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManagementDto managementDto)
        {
            _managementLogic.Create(managementDto);

            return Ok(managementDto);
        }

        [HttpPut("{laboratoryManagementEntityId:guid}")]
        public IActionResult Update([FromBody] ManagementDto managementDto, [FromRoute] Guid laboratoryManagementEntityId)
        {
            var result = _managementLogic.Update(managementDto, laboratoryManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{laboratoryManagementEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid laboratoryManagementEntityId)
        {
            var result = _managementLogic.Delete(laboratoryManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{laboratoryManagementEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid laboratoryManagementEntityId)
        {
            var result = _managementLogic.GetById(laboratoryManagementEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<ManagementDto> GetAll()
        {
            var laboratoriesManagement = _managementLogic.GetAll();

            return laboratoriesManagement;
        }
    }
}