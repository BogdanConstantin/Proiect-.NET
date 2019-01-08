
namespace BusinessLogic.FilesHandler.Abstractions
{
    using Entities.FilesHandler;
    using Models.FilesHandler;
    using System;
    using System.Collections.Generic;

    public interface IFilesHandlerLogic
    {
        void Create(FileDto fileDto);

        File Update(FileDto fileDto, Guid fileEntityId);

        File Delete(Guid fileEntityId);

        FileDto GetById(Guid fileEntityId);

        ICollection<FileDto> GetByCourseId(Guid courseEntityId);

        ICollection<FileDto> GetAll();
    }
}
