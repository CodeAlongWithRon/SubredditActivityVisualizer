using SubredditActivityVisualizer.Infrastructure.Reddit.Subscribers;
using System.Threading.Tasks;

namespace SubredditActivityVisualizer.Application.Services
{
   public class GetSubscribersService : IGetSubscribersService
   {
      private readonly IGetSubscribersClient _getSubscribersClient;

      public GetSubscribersService(IGetSubscribersClient getSubscribersClient)
      {
         _getSubscribersClient = getSubscribersClient;
      }

      public async Task<int> GetAsync(string subreddit)
      {
         var result = await _getSubscribersClient.GetAsync(subreddit);
         return result.Data.Subscribers;
      }
   }
}
