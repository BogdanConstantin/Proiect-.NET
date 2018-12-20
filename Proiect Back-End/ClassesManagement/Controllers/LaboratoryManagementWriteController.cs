namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;
    using System;

    [Route("api/laboratory/manage")]
    [ApiController]
    public class LaboratoryManagementWriteController : ControllerBase
    {
        private readonly ILaboratoryManagementLogic _managementLogic;

        public LaboratoryManagementWriteController(ILaboratoryManagementLogic managementLogic)
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
            _managementLogic.Update(managementDto, laboratoryManagementEntityId);

            return NoContent();
        }

        [HttpDelete("{laboratoryManagementEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid laboratoryManagementEntityId)
        {
            _managementLogic.Delete(laboratoryManagementEntityId);

            return NoContent();
        }
    }
}