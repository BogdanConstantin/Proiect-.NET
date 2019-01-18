using System;

namespace Models.FilesHandler
{
    public class FileMetadataDto
    {
        public Guid EntityId { get; set; }
        public Guid CourseId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}
