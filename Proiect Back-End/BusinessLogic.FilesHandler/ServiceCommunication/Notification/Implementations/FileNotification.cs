using System.Threading.Tasks;
using BusinessLogic.FilesHandler.Abstractions;
using Entities.FilesHandler;

namespace BusinessLogic.FilesHandler.Implementations
{
    public class FileNotification : IFileNotification
    {
        public readonly IServiceClient ServiceClient;

        public FileNotification(IServiceClient serviceClient)
        {
            ServiceClient = serviceClient;
        }

        public Task<string> SendEmail(Notification notification)
        {
            return ServiceClient.Post("https://localhost:44398/api/v1/emails", notification);
        }
    }
}
