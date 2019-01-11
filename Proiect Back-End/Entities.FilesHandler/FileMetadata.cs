using Entities.ClassesManagement;
using System;

namespace Entities.FilesHandler
{
    public class FileMetadata : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
