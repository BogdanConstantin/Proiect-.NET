using Entities.FilesHandler;
using System.Threading.Tasks;

namespace BusinessLogic.FilesHandler.Abstractions
{
    public interface IFileNotification
    {
        Task<string> SendEmail(Notification notification);
    }
}
