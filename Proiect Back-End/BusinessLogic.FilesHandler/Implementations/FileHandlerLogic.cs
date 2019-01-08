using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.ClassesManagement.Implementations;
using BusinessLogic.FilesHandler.Abstractions;
using DataAccess.FilesHandler.Abstractions;
using Entities.FilesHandler;
using Models.FilesHandler;

namespace BusinessLogic.FilesHandler.Implementations
{
    public class FileHandlerLogic : BaseLogic, IFilesHandlerLogic 
    {
        public FileHandlerLogic(IRepository repository)
            : base(repository)
        {
        }

        public void Create(FileDto fileDto)
        {
            var newCourse = new File
            {
                AuthorId = Guid.NewGuid(),
                EntityId = Guid.NewGuid(),
                CourseId = fileDto.CourseId,
                Path = fileDto.Path
            };

            _repository.Insert(newCourse);
            _repository.Save();
        }

        public File Update(FileDto fileDto, Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<File>(c => c.EntityId == fileEntityId);

            if (file.DeletedDate != null)
            {
                return null;
            }

            file.Id = Guid.NewGuid();
            file.AuthorId = Guid.NewGuid();
            file.CourseId = fileDto.CourseId;
            file.Path = fileDto.Path;

            _repository.Insert(file);
            _repository.Save();

            return file;
        }

        public File Delete(Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<File>(f => f.EntityId == fileEntityId);

            file.Id = Guid.NewGuid();
            file.AuthorId = Guid.NewGuid();
            file.DeletedDate = DateTime.Now;

            _repository.Insert(file);
            _repository.Save();

            return file;
        }

        public FileDto GetById(Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<File>(f => f.EntityId == fileEntityId);

            var fileDto = new FileDto
            {
                CourseId = file.CourseId,
                Path = file.Path
            };

            return fileDto;
        }

        public ICollection<FileDto> GetByCourseId(Guid courseEntityId)
        {
            List<FileDto> fileDtos = new List<FileDto>();

            var files = _repository.GetAll<File>();

            foreach (var file in files)
            {
                if (file.CourseId == courseEntityId)
                {
                    var fileDto = new FileDto
                    {
                        CourseId = file.CourseId,
                        Path = file.Path
                    };

                    fileDtos.Add(fileDto);
                }
            }

            return fileDtos;
        }

        public ICollection<FileDto> GetAll()
        {
            List<FileDto> fileDtos = new List<FileDto>();

            var files = _repository.GetAll<File>();

            foreach (var file in files)
            {
                var fileDto = new FileDto
                {
                    CourseId = file.CourseId,
                    Path = file.Path
                };

                fileDtos.Add(fileDto);
            }

            return fileDtos;
        }
    }
}
