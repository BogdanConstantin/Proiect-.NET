using System.Threading.Tasks;

namespace BusinessLogic.Gamification.Abstractions
{
    public interface IServiceClient
    {
        Task<string> Get(string url);
       
        Task<string> Post(string url, object data);
    }
}
