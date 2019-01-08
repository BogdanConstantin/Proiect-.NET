namespace ClassesManagement.Controllers
{
    using System;
    using System.Collections.Generic;
    using BusinessLogic.FilesHandler.Abstractions;
    using Microsoft.AspNetCore.Mvc;

    using Models.FilesHandler;

    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/files")]
    public class FilesHandlerController : ControllerBase
    {
        private readonly IFilesHandlerLogic _filesHandlerLogic;

        public FilesHandlerController(IFilesHandlerLogic filesHandlerLogic)
        {
            _filesHandlerLogic = filesHandlerLogic;
        }

        [HttpPost]
        public IActionResult Create([FromBody] FileDto fileDto)
        {
            _filesHandlerLogic.Create(fileDto);

            return Ok(fileDto);
        }

        [HttpPut("fileId={fileEntityId:guid}")]
        public IActionResult Update([FromBody] FileDto fileDto, [FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.Update(fileDto, fileEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("fileId={fileEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.Delete(fileEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("fileId={fileEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.GetById(fileEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("courseId={courseEntityId:guid}")]
        public IActionResult GetByCourseId([FromRoute] Guid courseEntityId)
        {
            var result = _filesHandlerLogic.GetByCourseId(courseEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<FileDto> GetAll()
        {
            var result = _filesHandlerLogic.GetAll();

            return result;
        }
    }
}
