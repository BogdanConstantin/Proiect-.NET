namespace FilesHandler.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
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
        public async Task<IActionResult> UploadFilesTask([FromRoute] Guid courseEntityId, List<IFormFile> files)
        {
            return Ok(await _filesHandlerLogic.UploadFiles(courseEntityId, files));
        }

        [HttpPut("fileId={fileEntityId:guid}")]
        public IActionResult Update([FromBody] FileMetadataDto fileMetadataDto, [FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.UpdateMetadata(fileMetadataDto, fileEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("fileId={fileEntityId:guid}")]
        public IActionResult Delete([FromRoute] Guid fileEntityId)
        {
            var result = _filesHandlerLogic.DeleteMetadata(fileEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("fileId={fileEntityId:guid}")]
        public IActionResult GetById([FromRoute] Guid fileEntityId)
        {
            var metadata = _filesHandlerLogic.GetMetadataById(fileEntityId);

            if (metadata == null)
            {
                return NotFound();
            }

            Stream stream = new FileStream(metadata.Path + metadata.FileName, FileMode.Open);

            if (stream == null)
                return NotFound();

            return File(stream, "application/octet-stream", metadata.FileName);
        }

        [HttpGet("courseId={courseEntityId:guid}")]
        public IActionResult GetByCourseId([FromRoute] Guid courseEntityId)
        {
            var result = _filesHandlerLogic.GetMetadataByCourseId(courseEntityId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        public ICollection<FileMetadataDto> GetAll()
        {
            var result = _filesHandlerLogic.GetAllMetadata();

            return result;
        }
    }
}
