using BusinessLogic.Gamification.Abstractions;
using Entities.Gamification;
using System.Threading.Tasks;

namespace BusinessLogic.Gamification.Implementations
{
    public class SessionNotification : ISessionNotification
    {
        public readonly IServiceClient ServiceClient;

        public SessionNotification(IServiceClient serviceClient)
        {
            ServiceClient = serviceClient;
        }

        public Task<string> SendEmail(Notification notification)
        {
            return ServiceClient.Post("https://localhost:44398/api/v1/emails", notification);
        }
    }
}
