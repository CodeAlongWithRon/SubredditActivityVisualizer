using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers
{
   public interface IGetSubscribersClient
   {
      Task<SubredditAboutResponse> GetAsync(string subreddit);
   }
}