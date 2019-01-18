using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.FilesHandler.Abstractions;
using DataAccess.FilesHandler.Abstractions;
using Entities.FilesHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.FilesHandler;
using Newtonsoft.Json.Linq;

namespace BusinessLogic.FilesHandler.Implementations
{
    public class FileHandlerLogic : BaseLogic, IFilesHandlerLogic
    {
        public readonly IFileClassesCommunication _fileClassesCommunication;
        public readonly IFileNotification _fileNotification;

        public FileHandlerLogic(IRepository repository, IFileClassesCommunication fileClassesCommunication, IFileNotification fileNotification)
            : base(repository)
        {
            _fileClassesCommunication = fileClassesCommunication;
            _fileNotification = fileNotification;
        }

        public async Task<FileMetadataDto> UploadFiles(Guid courseId, IFormFile file)
        {
            var course = _fileClassesCommunication.GetCourse(courseId);

            if (course.Result == null || course.Result.Length == 0)
                return null;

            // full path to file in temp location
            FileMetadataDto result = null;
            
            if (file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                // copy files to temp location for checking
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // check if files valid
                if (CheckFileValid(filePath))
                {
                    // create folder if it doesn't exists
                    if (!Directory.Exists("../files/" + courseId.ToString() + "/"))
                    {
                        Directory.CreateDirectory("../files/" + courseId.ToString() + "/");
                    }

                    var path = "../files/" + courseId.ToString() + "/";
                    // download files to server folder
                    using (var stream = new FileStream(path + file.FileName, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // create metadatas
                    result = new FileMetadataDto
                    {
                        EntityId = Guid.NewGuid(),
                        CourseId = courseId,
                        Path = path,
                        FileName = file.FileName
                    };

                

                    // delete temp files after processing
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                }
            }

            var body = "The file '" + result.FileName + "' was added for the course '" + JObject.Parse(course.Result)["courseTitle"] + "'!";
            var notification = new Notification
            {
                Subject = "A new file was added for one of your courses!",
                Body = body,
                Receiver = "mihai.catalin197@gmail.com"
            };

            await _fileNotification.SendEmail(notification);

            return result;
        }

        public bool CheckFileValid(string filePath)
        {
            if (filePath == null)
                return false;

            byte[] BMP = { 66, 77 };
            byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
            byte[] JPG = { 255, 216, 255 };
            byte[] PDF = { 37, 80, 68, 70, 45 };
            byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
            byte[] RAR = { 82, 97, 114, 33, 26, 7, 0 };
            byte[] ZIP_DOCX = { 80, 75, 3, 4 };

            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(stream);
            byte[] file = null;
            file = reader.ReadBytes(32);
            reader.Close();
            stream.Close();

            if (file.Take(2).SequenceEqual(BMP))
            {
                return true;
            }
            else if (file.Take(8).SequenceEqual(DOC))
            {
                return true;
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                return true;
            }
            else if (file.Take(5).SequenceEqual(PDF))
            {
                return true;
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                return true;
            }
            else if (file.Take(7).SequenceEqual(RAR))
            {
                return true;
            }
            else if (file.Take(4).SequenceEqual(ZIP_DOCX))
            {
                return true;
            }

            return false;
        }

        public FileMetadata Create(FileMetadataDto fileMetadataDto)
        {
            var newFileMetadata = new FileMetadata
            {
                AuthorId = Guid.NewGuid(),
                EntityId = fileMetadataDto.EntityId,
                CourseId = fileMetadataDto.CourseId,
                Path = fileMetadataDto.Path,
                FileName = fileMetadataDto.FileName
            };

            _repository.Insert(newFileMetadata);
            _repository.Save();

            return newFileMetadata;
        }

        public FileMetadata Update(FileMetadataDto fileMetadataDto, Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<FileMetadata>(c => c.EntityId == fileEntityId);

            if (file.DeletedDate != null)
            {
                return null;
            }

            if (file == null)
                return null;

            file.Id = Guid.NewGuid();
            file.AuthorId = Guid.NewGuid();
            file.CourseId = fileMetadataDto.CourseId;
            file.Path = fileMetadataDto.Path;

            _repository.Insert(file);
            _repository.Save();

            return file;
        }

        public FileMetadata Delete(Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<FileMetadata>(f => f.EntityId == fileEntityId);

            file.Id = Guid.NewGuid();
            file.AuthorId = Guid.NewGuid();
            file.DeletedDate = DateTime.Now;

            _repository.Insert(file);
            _repository.Save();

            if (File.Exists(file.Path + file.FileName))
            {
                File.Delete(file.Path + file.FileName);
            }

            return file;
        }

        public FileMetadataDto GetById(Guid fileEntityId)
        {
            var file = _repository.GetLastByFilter<FileMetadata>(f => f.EntityId == fileEntityId);

            var fileDto = new FileMetadataDto
            {
                EntityId = file.EntityId,
                CourseId = file.CourseId,
                Path = file.Path,
                FileName = file.FileName
            };

            return fileDto;
        }

        public ICollection<FileMetadataDto> GetByCourseId(Guid courseEntityId)
        {
            List<FileMetadataDto> fileDtos = new List<FileMetadataDto>();

            var files = _repository.GetAll<FileMetadata>();

            foreach (var file in files)
            {
                if (file.CourseId == courseEntityId)
                {
                    var fileDto = new FileMetadataDto
                    {
                        EntityId = file.EntityId,
                        CourseId = file.CourseId,
                        Path = file.Path,
                        FileName = file.FileName
                    };

                    fileDtos.Add(fileDto);
                }
            }

            return fileDtos;
        }

        public ICollection<FileMetadataDto> GetAll()
        {
            List<FileMetadataDto> fileDtos = new List<FileMetadataDto>();

            var files = _repository.GetAll<FileMetadata>();

            foreach (var file in files)
            {
                var fileDto = new FileMetadataDto
                {
                    EntityId = file.EntityId,
                    CourseId = file.CourseId,
                    Path = file.Path,
                    FileName = file.FileName
                };

                fileDtos.Add(fileDto);
            }

            return fileDtos;
        }

        public FileStreamResult GetFile(Guid fileEntityId, ControllerBase controller)
        {
            var metadata = GetById(fileEntityId);

            if (metadata == null)
                return null;

            Stream stream = new FileStream(metadata.Path + metadata.FileName, FileMode.Open);

            if (stream == null)
                return null;

            return controller.File(stream, "application/octet-stream", metadata.FileName);
        }
    }
}
