using Entities.ClassesManagement;
using System;

namespace Entities.FilesHandler
{
    public class File : BaseEntity
    {
        public Course Course { get; set; }
        public Guid CourseId { get; set; }
        public string Path { get; set; }
    }
}
