namespace FilesHandler.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusinessLogic.FilesHandler.Abstractions;
    using Microsoft.AspNetCore.Http;
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

        [HttpGet("{courseEntityId:guid}/upload")]
        public ActionResult UploadPage(List<IFormFile> files)
        {
            return File("~/UploadPage.html", "text/html");
        }

        [HttpPost("{courseEntityId:guid}/upload")]
        public async Task<IActionResult> UploadFilesTask([FromRoute] Guid courseEntityId, IFormFile file)
        {
            var fileDto = await _filesHandlerLogic.UploadFiles(courseEntityId, file);

            if (fileDto == null)
                return NotFound("Course not found!");

            var newFile = _filesHandlerLogic.Create(fileDto);

            return CreatedAtAction(nameof(GetById), new { fileEntityId = newFile.EntityId }, fileDto);
        }

        [HttpPut("fileId={fileEntityId:guid}")]
        public IActionResult Update([FromBody] FileMetadataDto fileMetadataDto, [FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.Update(fileMetadataDto, fileEntityId);

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
            var file = _filesHandlerLogic.GetFile(fileEntityId, this);

            if (file == null)
            {
                return NotFound();
            }

            return file;
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
        public ICollection<FileMetadataDto> GetAll()
        {
            var result = _filesHandlerLogic.GetAll();

            return result;
        }
    }
}
