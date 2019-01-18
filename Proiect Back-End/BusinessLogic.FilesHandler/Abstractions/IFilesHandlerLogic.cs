
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.FilesHandler.Abstractions
{
    using Entities.FilesHandler;
    using Microsoft.AspNetCore.Http;
    using Models.FilesHandler;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFilesHandlerLogic
    {
        Task<FileMetadataDto> UploadFiles(Guid courseId, IFormFile file);

        FileMetadata Create(FileMetadataDto fileMetadataDto);

        FileMetadata Update(FileMetadataDto fileMetadataDto, Guid fileEntityId);

        FileMetadata Delete(Guid fileEntityId);

        FileMetadataDto GetById(Guid fileEntityId);

        ICollection<FileMetadataDto> GetByCourseId(Guid courseEntityId);

        ICollection<FileMetadataDto> GetAll();

        bool CheckFileValid(string filePath);

        FileStreamResult GetFile(Guid fileEntityId, ControllerBase controller);
    }
}
