using System;
using System.Threading.Tasks;

namespace BusinessLogic.FilesHandler.Abstractions
{
    public interface IFileClassesCommunication
    {
        Task<string> GetCourse(Guid courseId);
    }
}
