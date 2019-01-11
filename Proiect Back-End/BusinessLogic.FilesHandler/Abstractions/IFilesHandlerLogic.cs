
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
        Task<Object> UploadFiles(Guid courseId, List<IFormFile> files);

        void CreateMetadata(FileMetadataDto fileMetadataDto);

        FileMetadata UpdateMetadata(FileMetadataDto fileMetadataDto, Guid fileEntityId);

        FileMetadata DeleteMetadata(Guid fileEntityId);

        FileMetadataDto GetMetadataById(Guid fileEntityId);

        ICollection<FileMetadataDto> GetMetadataByCourseId(Guid courseEntityId);

        ICollection<FileMetadataDto> GetAllMetadata();
    }
}
