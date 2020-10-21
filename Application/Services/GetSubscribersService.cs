using SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Application.Services
{
   public class GetSubscribersService
   {
      public async Task<int> GetAsync(string subreddit)
      {
         var client = new GetSubscribersClient();
         var result = await client.GetAsync(subreddit);

         return result.Data.Subscribers;
      }
   }
}
