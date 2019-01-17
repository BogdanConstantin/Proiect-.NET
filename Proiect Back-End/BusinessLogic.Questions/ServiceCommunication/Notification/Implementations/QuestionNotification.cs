using System.Threading.Tasks;
using BusinessLogic.Questions.Abstractions;
using Entities.Questions;

namespace BusinessLogic.Questions.Implementations
{
    public class QuestionNotification : IQuestionNotification
    {
        public readonly IServiceClient ServiceClient;

        public QuestionNotification(IServiceClient serviceClient)
        {
            ServiceClient = serviceClient;
        }

        public Task<string> SendEmail(Notification notification)
        {
            return this.ServiceClient.Post("https://localhost:44398/api/v1/emails", notification);
        }
    }
}
