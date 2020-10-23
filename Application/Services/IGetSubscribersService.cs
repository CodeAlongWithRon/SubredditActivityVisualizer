using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Application.Services
{
   public interface IGetSubscribersService
   {
      Task<int> GetAsync(string subreddit);
   }
}