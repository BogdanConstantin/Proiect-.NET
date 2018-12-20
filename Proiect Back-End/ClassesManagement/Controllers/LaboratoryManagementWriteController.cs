namespace ClassesManagement.Controllers
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;

    using Microsoft.AspNetCore.Mvc;

    using Models.ClassesManagement;

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
    }
}