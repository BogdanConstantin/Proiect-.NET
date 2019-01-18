using BusinessLogic.FilesHandler.Abstractions;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.FilesHandler.Implementations
{
    public class FileClassesCommunication : IFileClassesCommunication
    {
        public readonly IServiceClient ServiceClient;

        public FileClassesCommunication(IServiceClient serviceClient)
        {
            ServiceClient = serviceClient;
        }

        public Task<string> GetCourse(Guid courseId)
        {
            return this.ServiceClient.Get("https://localhost:44381/api/v1/courses/" + courseId.ToString());
        }
    }
}
