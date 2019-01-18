using Entities.Gamification;
using System.Threading.Tasks;

namespace BusinessLogic.Gamification.Abstractions
{
    public interface ISessionNotification
    {
        Task<string> SendEmail(Notification notification);
    }
}
