using Entities.Questions;
using System.Threading.Tasks;

namespace BusinessLogic.Questions.Abstractions
{
    public interface IQuestionNotification
    {
        Task<string> SendEmail(Notification notification);
    }
}
